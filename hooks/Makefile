GIT-HOOKS = ../.git/hooks/
PYTHON=python3.6

.PHONY: lint, install
lint:
	@$(PYTHON) -m flake8 .

install: lint
	cp $(PYTHON) ./hook_utils.py $(GIT-HOOKS)
	cp $(PYTHON) ./prepare-commit-msg $(GIT-HOOKS)
	cp $(PYTHON) ./pre-commit $(GIT-HOOKS)
