from fastapi import FastAPI
from pydantic import BaseModel
from typing import Union
from typing import List
from datetime import datetime
import json
import math
import uvicorn


app = FastAPI()

# to start the API:
# uvicorn index:app --reload
# and install all the modules of course :)


class Card(BaseModel):
    name: str
    value: Union[int, None] = None


class Cards(BaseModel):
    cards: List[Card]
    total_value: Union[int, None] = None


def update_total_score(cards: Cards):
    sum = 0
    for card in cards.cards:
        sum += card.value
    cards.total_value = sum
    return cards

card1 = Card(name='5h', value=3)
card2 = Card(name='9s', value=9)
cards = Cards(cards=[card1,card2])

print(cards)
@app.post('/cardmania/predict')
def predict(cards: Cards):
    # 1) get image (as unknown source?)
    # 2) run image through model
    # 3) make card objects out of prediction
    # 4) return cards and total score
    update_total_score(cards)
    return cards.total_value


# Breadr:

@app.post('/breadr/getProduct')
def get_product(gate_id):
    now =  datetime.now()
    bread = {
        "id": 9,
        "name": "Baguette",
        "quantity": 9,
        "price": 2.04,
        "active": True,
        "imageUrl": "bread.jpg",
        "timeStamp": math.floor(datetime.timestamp(now))
    }
    return bread

@app.post('/breadr/buyProduct')
def buy_product(user_id, gate_id):
    now =  datetime.now()
    response = {
        "gateId": 1,
        "transactionStatus": True,
        "name": 'Baguette',
        "price": 1.49,
        "timeStamp": math.floor(datetime.timestamp(now))
    }
    return response

@app.get('/breadr/bread')
def return_bread():
    now =  datetime.now()
    bread = {
        "id": 9,
        "name": "Baguette",
        "quantity": 9,
        "price": 2.04,
        "active": True,
        "timeStamp": math.floor(datetime.timestamp(now))
    }
    return bread


@app.post('/breadr/login')
def login():
    now =  datetime.now()
    response = {
        "status": True,
        "timeStamp": math.floor(datetime.timestamp(now))
    }
    return response

@app.post('/breadr/register')
def sign_up():
    now =  datetime.now()
    response = {
        "status": True,
        "timeStamp": math.floor(datetime.timestamp(now))
    }
    return response