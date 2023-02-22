FROM python:3.10

LABEL maintainer="kenwood364@gmail.com"

COPY . /app

WORKDIR /app

RUN pip install -r requirements.txt

# Git commit
ARG GIT_COMMIT
ENV GIT_COMMIT=$GIT_COMMIT

EXPOSE 8080

ENTRYPOINT ["python"]

CMD ["app/app.py"]
