import socket
import json
PORT = 8876
MAX_PORT_TO_SCAN = 65535
MIN_PORT_TO_SCAN = 1024

CODE_SIZE = 1
LEN_SIZE = 4

USERNAME = "username"
PASSWORD = "password"
EMAIL = "email"

EXIT_CODE = 0
SIGNUP_CODE = 1
LOGIN_CODE = 2

""" Deserialize response data buffer into json data
    :param data_buffer (bytes): response data from server
    :return json data 
    :rtype json """
def deserialize_response(data_buffer):
    return json.dumps(data_buffer.decode())

""" Serialize json request data into a data buffer
    :param code (int): request code type
    :param sock (socket): socket to server
    :return request data buffer 
    :rtype bytes """
def serialize_request(code, json_data):
    data_buffer = code.to_bytes(CODE_SIZE, byteorder='big')
    data_buffer += len(json_data).to_bytes(LEN_SIZE, byteorder='big')
    data_buffer += json_data.encode()
    return data_buffer


""" Receive a response from server
    :param sock (socket): socket to server
    :return json data
    :rtype json """
def receive_response(sock):
    try:
        code = sock.recv(CODE_SIZE)
        code = int.from_bytes(code, byteorder='big')
        len = sock.recv(LEN_SIZE)
        len = int.from_bytes(len, byteorder='big')
        data_buffer = sock.recv(len)
    except Exception as e:
        print("Couldn't get response from server: ", e)
    return deserialize_response(data_buffer)

""" Sends a request to the server
    :param code (int): request code type
    :param sock (socket): socket to server
    :param json_data (json): json data to send """
def send_request(code, sock, json_data):
    data_buffer = serialize_request(code, json_data)
    try:
        sock.sendall(data_buffer)
    except Exception as e:
        print("Couldn't send request to server: ", e)

""" Sends a login request to the server
    :param sock (socket): socket to server """
def send_login_request(sock):
    username = input("Please enter your username: ")
    password = input("Please enter your password: ")
    json_data = json.dumps({USERNAME: username, PASSWORD: password})
    send_request(LOGIN_CODE, sock, json_data)

""" Sends a signup request to the server
    :param sock (socket): socket to server """
def send_signup_request(sock):
    username = input("Please choose a username: ")
    password = input("Please choose a password: ")
    email = input("Please choose an email address: ")
    json_data = json.dumps({USERNAME: username, PASSWORD: password, EMAIL: email})
    send_request(SIGNUP_CODE, sock, json_data)

""" Prints the choice menu"""
def print_menu():
    print(""" Please choose one of these options:
0. Exit
1. Signup
2. Login 
""")

def main():
    try:
        sock = socket.socket(socket.AF_INET , socket.SOCK_STREAM)
        sock.connect(("localhost" , int(PORT)))
        if sock.getsockname()[1] > MAX_PORT_TO_SCAN or sock.getsockname()[1] < MIN_PORT_TO_SCAN:
            raise Exception("Invalid port")
    except Exception as e:
        print("problem to connect to server: ", e)
        return -1
    while True:
        print_menu()
        choice = int(input())
        if choice == EXIT_CODE:
            print("Goodbye.")
            break
        elif choice == SIGNUP_CODE:
            send_signup_request(sock)
        elif choice == LOGIN_CODE:
            send_login_request(sock)
        else:
            print("Error, invalid message")
            continue
        data = json.loads(receive_response(sock)) #turn json data into string
        data = json.loads(data) # turn string to dictionary
        print(data)
    sock.close()

if __name__ == "__main__":
    main()