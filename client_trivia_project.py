import socket
PORT = 8876
MAX_PORT_TO_SCAN = 65535
MIN_PORT_TO_SCAN = 1024


def send_hello(sock):
    sock.send(b'Hello')


def main():
    try:
        sock = socket.socket(socket.AF_INET , socket.SOCK_STREAM)
        sock.connect(("localhost" , int(PORT)))
        if sock.getsockname()[1] > MAX_PORT_TO_SCAN or sock.getsockname()[1] < MIN_PORT_TO_SCAN:
            return "Invalid port"
    except:
        print("problem to connect to server")

    msg = sock.recv(1024).decode();
    if msg == "Hello":
        send_hello(sock)
    sock.close()

if __name__ == "__main__":
    main()