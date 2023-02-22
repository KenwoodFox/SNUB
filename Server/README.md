# The Server Component

This part of the app runs online and provides the super basic
database structure for the app.


## Developing Locally

You can begin a local development session like so

(You can use any venv software, pipenv is just easier for me)

```
pipenv install -r requirements.txt
pipenv shell
cd app
flask run
```


## Running with docker

You can locally run the server using

```
make dev
```
