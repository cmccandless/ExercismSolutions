TRACKS = $(shell ls -d */)

.PHONY: init lint

init:
	@pip install -r requirement-travis.txt

lint:
	@ $(foreach TRACK,$(TRACKS), \
		$(call dolint,$(TRACK)) \
	)

echo:
	@echo $@

define dolint
	$(MAKE) -C ./$(1) lint
endef
