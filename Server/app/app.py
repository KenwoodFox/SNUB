# CS-114

# External libs
import os

from flask import Flask, render_template, jsonify, request


# Our own
from tools.misc import get_uptime

app = Flask(__name__)


@app.route("/")
def index():
    try:
        return render_template("index.html", uptime=get_uptime())
    except:
        return render_template("error.html")


# Some basic testing routes!
@app.route("/cmds/version", methods=["GET"])
def version():
    return jsonify(version=os.getenv("GIT_COMMIT"))


# All possible classes
@app.route("/cmds/classes", methods=["GET"])
def classes():
    return jsonify(["CS-114", "CS-113", "CUL-155"])


# Class data
@app.route("/cmds/class_notes", methods=["GET"])
def class_notes():
    args = request.args
    class_sel = args.get("class")

    data = {
        "CS-114": ["Example 1", "Example 2", "Example 3"],
        "CS-113": ["Example 9", "Example 420", "Example 69"],
        "CUL-155": ["Why are you taking this class?"],
    }

    try:
        return jsonify(data[str(class_sel)])
    except KeyError:
        return jsonify([f"No Data for class: {class_sel}"])


if __name__ == "__main__":
    app.run(host="0.0.0.0", port=8080)
