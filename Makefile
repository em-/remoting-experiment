common_SOURCES := DoSomething.cs Remoting.cs 
main_EXE := RemotingExperiment.exe
helper_EXE := RemotingHelper.exe
REFERENCES := $(addprefix -r:, Mono.Posix)

MCS := gmcs
MONO := mono --debug

all: $(main_EXE) $(helper_EXE)

run: $(main_EXE) $(helper_EXE)
	@${MONO} $(main_EXE)

clean:
	-rm -Rf $(main_EXE) $(helper_EXE)

%.exe: $(common_SOURCES) %.cs
	$(MCS) $(REFERENCES) -out:"$@" $^
