# CS-114

# External libs
from flask import Flask, render_template
import socket

# Our own
from tools.misc import get_uptime

app = Flask(__name__)


@app.route("/")
def index():
    try:
        return render_template("index.html", uptime=get_uptime())
    except:
        return render_template("error.html")


if __name__ == "__main__":
    app.run(host="0.0.0.0", port=8080)
