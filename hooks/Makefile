GIT-HOOKS = ../.git/hooks/
PYTHON=python3.6

.PHONY: init, lint, install
init:
	@$(PYTHON) -m pip install -r requirements.txt

lint:
	@$(PYTHON) -m flake8 .

install: lint
	cp ./hook_utils.py $(GIT-HOOKS)
	cp ./prepare-commit-msg $(GIT-HOOKS)
	chmod +x $(GIT-HOOKS)prepare-commit-msg
	cp ./pre-commit $(GIT-HOOKS)
	chmod +x $(GIT-HOOKS)pre-commit
