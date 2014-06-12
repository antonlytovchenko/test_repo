from flask import url_for
from emptyfridge import db


class Recipes(db.Document):
    name = db.StringField(max_length=255, required=True)
    description = db.StringField()
    ingredients = db.ListField(db.StringField())
    dishType = db.StringField(max_length=255)
    typeKitchen = db.StringField()
    picture = db.StringField()