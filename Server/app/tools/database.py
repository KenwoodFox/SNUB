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
                    title text,
                    author text,
                    note text)
                """
            )

            # Commit the db changes!
            self.conn.commit()

    def getNotes(rclass: str) -> str:
        pass
