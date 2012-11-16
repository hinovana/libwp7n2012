CC = cl
LINK = link
CFLAGS = /MT /W4 /Ox /c /nologo
TARGET = libwp7m2008.dll
OBJS = libwp7m2008.obj

all: $(TARGET)

$(TARGET): $(OBJS)
	$(CC) /nologo /LD /Fe"$@" $(OBJS) user32.lib

example: example.obj
	$(CC) /nologo /Fe"$@" example.obj libwp7m2008.lib

clean:
	del /q *.obj *.lib *.exp

.c.obj:
	$(CC) $(CFLAGS) /DBUILDING_LIBWP7M2008_SHARED $<

example.obj:
	$(CC) $(CFLAGS) /DUSING_LIBWP7M2008_SHARED example.c

libwp7m2008.obj: libwp7m2008.h
example.obj: libwp7m2008.h
