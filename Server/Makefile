.PHONY: help clean run build

# Help
help:
	@echo " help  -         Prints this help."
	@echo " clean -         Shortcut for git clean -fdX"
	@echo " build -         Builds the required containers locally"
	@echo " dev   -         Build and run the app locally"

# For local development
dev: build
	# docker-compose -f docker-compose.yml build && docker-compose -f docker-compose.yml up
	docker-compose -f docker-compose.yml up

# Build container locally
build:
	# Generate tag
	echo TAG=$(shell git rev-parse --abbrev-ref HEAD | sed 's/[^a-zA-Z0-9]/-/g') > .env

	# Build
	docker-compose build --build-arg GIT_COMMIT=$(shell git describe --abbrev=8 --always --tags --dirty) --build-arg DEBUG=True


clean:
	git clean -fdx