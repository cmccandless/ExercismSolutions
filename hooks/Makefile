GIT-HOOKS = ../.git/hooks/

.PHONY: lint, install
lint:
	@flake8

install: lint
	cp ./hook_utils.py $(GIT-HOOKS)
	cp ./prepare-commit-msg $(GIT-HOOKS)
	cp ./pre-commit $(GIT-HOOKS)
