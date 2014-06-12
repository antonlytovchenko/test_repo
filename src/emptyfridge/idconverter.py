from werkzeug.routing import BaseConverter


class ObjectIDConverter(BaseConverter):
    def to_url(self, value):
        return str(value)