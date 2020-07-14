import requests
import html
import random
from pymongo import MongoClient

QUESTION_AMOUNT = 50


def main():
    response = requests.get('https://opentdb.com/api.php?amount=' + str(QUESTION_AMOUNT) + '&type=multiple')
    questions = response.json()['results']
    for i in range(len(questions)): # get only important data about the question
        question = dict()
        question['id'] = i
        question['question'] = html.unescape(questions[i]['question'])
        question['correct_answer'] = html.unescape(questions[i]['correct_answer'])
        question['answers'] = questions[i]['incorrect_answers']
        question['answers'].insert(random.randint(0, 4), questions[i]['correct_answer'])
        for j in range(len(question['answers'])):
            question['answers'][j] = html.unescape(question['answers'][j].replace('\'', '"'))
        questions[i] = question
    client = MongoClient()
    db = client['mydb']
    question_col = db['Questions']
    question_col.drop() # reset questions
    question_col.insert_many(questions)


if __name__ == "__main__":
    main()
