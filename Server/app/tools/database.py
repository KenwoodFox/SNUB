import time
import psycopg


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

    def getNotes(self, _class: str, lines: int = 10) -> str:
        ret = []
        with self.conn.cursor() as cur:
            cur.execute(
                "SELECT * FROM notes WHERE class = %s ORDER BY timestamp DESC LIMIT %s",
                (
                    _class,
                    lines,
                ),
            )

            for item in cur:
                ret.append(item)

        return ret

    def getClasses(self):
        """
        Returns a list of all currently cataloged classes
        """

        classes = []
        with self.conn.cursor() as cur:
            cur.execute("SELECT DISTINCT class FROM notes")
            for record in cur:
                classes.append(record[0])
        return classes
