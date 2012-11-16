#ifndef _HOGE_H__
#define _HOGE_H__

#include <assert.h>

extern unsigned long globalline;

typedef unsigned long NODE;

typedef enum NodeType {
	NODE_CSTRUCT = 1,
	NODE_CS_CODE,
} NodeType;

typedef struct Node {
	NodeType type;
	union {
		struct CStruct *cstruct;
		char *cs_code;
	} u;
} Node;

typedef struct NodeList {
	Node *node;
	struct NodeList *next;
} NodeList;

typedef enum Sign {
	SIGN_SIGNED = 1,
	SIGN_UNSIGNED,
} Sign;

typedef enum Specifier {
	SPECIFIER_CHAR = 1,
	SPECIFIER_INT,
	SPECIFIER_SHORT,
} Specifier;

typedef struct DocComment {
	char *summary;
	char *description;
} DocComment;

typedef struct Declaration {
	Sign sign;
	Specifier specifier;
	char *identifier;
	int using_nbits_opt;
	unsigned int nbits;
	DocComment *doc_comment;
} Declaration;

typedef struct DeclarationList {
	Declaration *declaration;
	struct DeclarationList *next;
} DeclarationList;

typedef struct CStruct {
	char *identifier;
	DeclarationList *list;
} CStruct;


#define MY_STRIMG_MIN_BLOCK   (1000)

typedef struct myString {
	char *str;
	unsigned int len;
	unsigned int capa;
} myString;

#define my_string_sprintfln(o,buff,...) do { \
	sprintf( buff, __VA_ARGS__ );\
	my_string_add_text( o, buff ); \
	my_string_add_text( o, "\n" ); \
} while(0)



extern NodeList *global_node_list;


CStruct *cstruct_new( char *identifier, DeclarationList *list );

NodeList *node_list_new( Node *node );
NodeList *node_list_add( NodeList *self, Node *node );
NodeList *node_list_each( NodeList *self, void (*each_func)( Node *node ) );

Declaration *declaration_new( Sign sign, Specifier specifier, char *identifier, int using_nbits_opt, unsigned int nbits, DocComment *doc_comment );

DeclarationList *declaration_list_new( Declaration *declaration );
DeclarationList *declaration_list_add( DeclarationList *self, Declaration *declaration );

Node *csharp_node_new( char *cs_code );
Node *cstruct_node_new( CStruct *cstruct );


myString *my_string_new( char *str );
void my_string_dispose( myString *self );
myString *my_string_clear( myString *self );
myString *my_string_concat( myString *self, myString *obj );
unsigned int my_string_length( myString *self );
myString *my_string_add_text( myString *self, char *str );

#endif

