# SNUB
SNhU dataBase. A CS-114 project for SNHU.

SNUB Is a student interactive bulliten board with the following features.

 - [ ] A simple fourm-like interface where students can tag specific classes with notes and comments
 - [ ] The ability to attach photos and larger notes
 - [ ] Ratings and a live map


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
