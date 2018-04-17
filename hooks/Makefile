PYTHON=python3.6

.PHONY: init, lint, install
init:
	@$(PYTHON) -m pip install -r requirements.txt

lint:
	@$(PYTHON) -m flake8 .

install: lint
	@$(PYTHON) install-hooks
