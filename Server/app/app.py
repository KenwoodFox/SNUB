# CS-114

# External libs
import os

from flask import Flask, render_template, jsonify


# Our own
from tools.misc import get_uptime

app = Flask(__name__)


@app.route("/")
def index():
    try:
        return render_template("index.html", uptime=get_uptime())
    except:
        return render_template("error.html")


@app.route("/cmds/version", methods=["GET"])
def version():
    return jsonify(version=os.getenv("GIT_COMMIT"))


if __name__ == "__main__":
    app.run(host="0.0.0.0", port=8080)
