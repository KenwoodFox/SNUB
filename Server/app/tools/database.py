import time
import pytz
import psycopg

from datetime import datetime


class database:
    """
    General class to nest all our DB stuff inside of.
    """

    def __init__(self) -> None:
        # Connect to DB
        self.conn = psycopg.connect(
            "dbname=snub_db user=postgres password=postgres host=database"
        )

        # Setup DB
        with self.conn.cursor() as cur:
            # Execute a command: this creates a new table
            cur.execute(
                """
                CREATE TABLE IF NOT EXISTS notes (
                    timestamp bigint,
                    class text,
                    author text,
                    note text)
                """
            )

            # Commit the db changes!
            self.conn.commit()

    def recordNote(self, _class: str, _author: str, _note: str):
        with self.conn.cursor() as cur:
            cur.execute(
                "INSERT INTO notes (timestamp, class, author, note) VALUES (%s, %s, %s, %s)",
                (
                    int(time.time()),
                    _class,
                    _author,
                    _note,
                ),
            )

            self.conn.commit()

    def delClass(self, _class: str):
        with self.conn.cursor() as cur:
            query = "DELETE FROM notes WHERE class = %s"
            cur.execute(query, (_class,))

            self.conn.commit()

    def getNotes(self, _class: str, lines: int = 10) -> str:
        ret = []
        if _class != "":
            with self.conn.cursor() as cur:
                cur.execute(
                    "SELECT * FROM notes WHERE class = %s ORDER BY timestamp DESC LIMIT %s",
                    (
                        _class,
                        lines,
                    ),
                )

                for item in cur:
                    ret.append(list(item))

            # Convert dates
            for item in ret:
                tme = datetime.fromtimestamp(item[0], tz=pytz.timezone("US/Eastern"))
                item[0] = tme.strftime("%m/%d/%Y, %-I:%M:%S %p")

        return ret

    def getClasses(self):
        """
        Returns a list of all currently cataloged classes
        """

        classes = []
        with self.conn.cursor() as cur:
            cur.execute("SELECT DISTINCT class FROM notes")
            for record in cur:
                if str(record[0]) != "":
                    classes.append(record[0])
        return classes
