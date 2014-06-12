from flask import Blueprint, request, redirect, render_template, url_for
from flask.views import MethodView

from bson.objectid import ObjectId

from emptyfridge.models import Recipes

recipes = Blueprint('recipes', __name__, template_folder='templates')


class ListView(MethodView):

    def get(self):
        all_recipes = Recipes.objects.all()
        return render_template('recipes/list.html', all_recipes=all_recipes)


class IndexView(MethodView):
    def get(self):
        return render_template('recipes/index.html')

    def post(self):
        query = request.form['query']
        ingredients = [x.strip().lower() for x in query.split()]
        if ingredients:
            recipes_list = Recipes.objects(ingredients__all=ingredients)
            return render_template('recipes/index.html', recipes_list=recipes_list)
        return render_template('recipes/index.html')


class DetailView(MethodView):
    def get(self, object_hash):
        recipe = Recipes.objects.get_or_404(id=ObjectId(object_hash))
        return render_template('recipes/detail.html', recipe=recipe)

recipes.add_url_rule('/', view_func=IndexView.as_view('index'))
recipes.add_url_rule('/all', view_func=ListView.as_view('list'))
recipes.add_url_rule('/recipe/<objectid:object_hash>', view_func=DetailView.as_view('detail'))