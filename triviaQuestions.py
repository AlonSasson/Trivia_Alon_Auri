import requests
import html
import random
from pymongo import MongoClient




def main():
    response = requests.get('https://opentdb.com/api.php?amount=50&type=multiple')
    questions = response.json()['results']
    for i in range(len(questions)): # get only important data about the question
        question = dict()
        question['question'] = html.unescape(questions[i]['question'])
        question['correct_answer'] = html.unescape(questions[i]['correct_answer'])
        question['answers'] = list(map(html.unescape, questions[i]['incorrect_answers']))
        question['answers'].insert(random.randint(0, 4), html.unescape(question['correct_answer']))
        questions[i] = question
    client = MongoClient()
    db = client['mydb']
    question_col = db['questions']
    question_col.drop() # reset questions
    question_col.insert_many(questions)


if __name__ == "__main__":
    main()
