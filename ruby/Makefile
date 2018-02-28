.PHONY: lint test
lint:
	@echo "No linter configured"

test:
	@ $(foreach FILE,$(FILES), \
		$(call dotest,$(FILE)) \
	)

test-all:
	@ $(foreach FILE,$(shell ls -d */), \
		$(call dotest, $(FILE)) \
	)

define dotest
	cd $(1); \
	ruby $(OPTS) *_test.rb; \
	cd ..;
endef
