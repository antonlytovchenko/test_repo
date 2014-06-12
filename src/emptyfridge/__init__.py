import socket

from flask import Flask
from flask.ext.mongoengine import MongoEngine

from emptyfridge.idconverter import ObjectIDConverter

app = Flask(__name__)

# For mongo ids in url
app.url_map.converters['objectid'] = ObjectIDConverter

app.config["MONGODB_SETTINGS"] = {
    'db': "Recipes",
    'host': "mongodb://mongo1.fridge:27017,mongo2.fridge:27017",
    'replicaset': 'rs0'
}
app.config["SECRET_KEY"] = "12345"

db = MongoEngine(app)

def register_blueprints(app):
    # Prevents circular imports
    from emptyfridge.views import recipes
    app.register_blueprint(recipes)

register_blueprints(app)

@app.context_processor
def get_hostname():
    return dict(hostname=socket.gethostname())

if __name__ == '__main__':
    app.run()
