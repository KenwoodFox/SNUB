# CS-114

# External libs
import os
import logging

from flask import Flask, render_template, jsonify, request


# Our own
from tools.misc import get_uptime
from tools.database import database

# Create objects
app = Flask(__name__)
db = database()


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


@app.route("/cmds/delclass", methods=["GET"])
def delclass():
    args = request.args
    passwd = args.get("passwd").strip('"')
    class_sel = args.get("class").strip('"')

    logging.info(f"Passwd was: {passwd}")

    if passwd == "iamnotacrook":
        db.delClass(class_sel)
        return jsonify(["Done"])

    return jsonify(["Nothing deleted."])


# All possible classes
@app.route("/cmds/classes", methods=["GET"])
def classes():
    return jsonify(db.getClasses())


# Class data
@app.route("/cmds/class_notes", methods=["GET"])
def class_notes():
    args = request.args
    class_sel = args.get("class").strip('"')

    try:
        return jsonify(db.getNotes(str(class_sel)))
    except KeyError:
        return jsonify([f"No Data for class: {class_sel}"])


@app.route("/cmds/publish", methods=["GET"])  # Should be a post request? idk...
def publish():
    """
    To publish here use something like this:
    https://snub.kitsunehosting.net/cmds/publish?author=Joe&class=CS-114&note=My note here!
    """
    args = request.args
    class_arg = args.get("class").strip('"')
    note_arg = args.get("note").strip('"')
    author_arg = args.get("author").strip('"')

    logging.info(f"{class_arg}, {note_arg}, {author_arg}")
    db.recordNote(class_arg, author_arg, note_arg)

    return jsonify(["Published!"])


if __name__ == "__main__":
    logging.basicConfig(level=logging.DEBUG)
    app.run(host="0.0.0.0", port=8080)
