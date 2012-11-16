CC = cl
CFLAGS = /O2 /W2 /DYY_NO_UNISTD_H /nologo /MT 
INCLUDES = 
LIBS =

BISON = bison
BISONFLAGS = -dv 

FLEX = flex
FLEXFLAGS = -8
SRC = .

OBJS = parse.obj lexer.obj hoge.obj

TARGET = c2sharp.exe

all: $(TARGET)

$(TARGET): $(OBJS)
	$(CC) $(CFLAGS) $(INCLUDES) /Fe"$@" $(OBJS)

.c.obj:
	$(CC) $(CFLAGS) /c $(INCLUDES) $<

parse.obj: parse.c parse.h
parse.h: parse.c
parse.c: $(SRC)/parse.y
	$(BISON) $(BISONFLAGS) -o $@ "$(SRC)/parse.y"

lexer.obj: lexer.c parse.h
lexer.c: $(SRC)/lexer.l
	$(FLEX) $(FLEXFLAGS) -o$@ "$(SRC)/lexer.l"

hoge.obj: hoge.h

clean:
	DEL /Q *.exe *.obj parse.c parse.h parse.output lexer.c

