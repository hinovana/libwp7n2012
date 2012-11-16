
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
#include "hoge.h"

NodeList *global_node_list = NULL;

Node *node_new( NodeType node_type )
{
	Node *self;
	
	self = malloc( sizeof(Node) );
	self->type = node_type;
	
	return self;
}

Node *cstruct_node_new( CStruct *cstruct )
{
	Node *self;
	
	self = node_new( NODE_CSTRUCT );
	self->u.cstruct = cstruct;
	
	return self;
}

Node *csharp_node_new( char *cs_code )
{
	Node *self;
	
	self = node_new( NODE_CS_CODE );
	self->u.cs_code = cs_code;
	
	return self;
}

CStruct *cstruct_new( char *identifier, DeclarationList *list )
{
	CStruct *self;
	
	self = malloc( sizeof(CStruct) );
	self->identifier = identifier;
	self->list = list;
	
	return self;
}

DeclarationList *declaration_list_new( Declaration *declaration )
{
	DeclarationList *self;
	
	self = malloc( sizeof(DeclarationList) );
	self->declaration = declaration;
	self->next = NULL;
	
	return self;
}

DeclarationList *declaration_list_add( DeclarationList *self, Declaration *declaration )
{
	DeclarationList *next = self;
	
	while(1) {
		if( next->next == NULL ) {
			next->next = declaration_list_new( declaration );
			break;
		}
		next = next->next;
	}
	return self;
}

Declaration *declaration_new( Sign sign, Specifier specifier, char *identifier, int using_nbits_opt, unsigned int nbits, DocComment *doc_comment )
{
	Declaration *self;
	
	self = malloc( sizeof(Declaration) );
	self->sign = sign;
	self->specifier = specifier;
	self->identifier = identifier;
	self->using_nbits_opt = using_nbits_opt;
	self->nbits = nbits;
	self->doc_comment = doc_comment;
	
	return self;
}



myString *my_string_new( char *str )
{
	myString *self;
	
	self = malloc( sizeof(myString) );
	self->capa = MY_STRIMG_MIN_BLOCK;
	self->str = malloc( self->capa );
	self->str[0] = '\0';
	self->len = strlen( str );
	my_string_add_text( self, str );
	
	return self;
}

void my_string_dispose( myString *self )
{
	free( self->str );
	free( self );
}


myString *my_string_add_text( myString *self, char *str )
{
	size_t len;
	
	len = strlen( str );
	
CHECK:
	if( self->capa <= ( self->len + len ) ) {
		self->capa += MY_STRIMG_MIN_BLOCK;
		if( (self->str = realloc( self->str, self->capa )) == NULL ) {
			abort();
		}
		goto CHECK;
	}
	strcat( self->str, str );
	self->len += len;

	return self;
}

myString *my_string_clear( myString *self )
{
	self->len = 0;
	self->str[0] = '\0';
	
	return self;
}

unsigned int my_string_length( myString *self )
{
	return self->len;
}

myString *my_string_concat( myString *self, myString *obj )
{
	return my_string_add_text( self, obj->str );
}


NodeList *node_list_new( Node *node )
{
	NodeList *self;
	
	self = malloc( sizeof(NodeList) );
	self->node = node;
	self->next = NULL;
	
	return self;
}

NodeList *node_list_add( NodeList *self, Node *node )
{
	NodeList *next;
	
	next = self;
	
	while(1) {
		if( next->next == NULL ) {
			next->next = node_list_new( node );
			break;
		}
		next = next->next;
	}
	return self;
}

NodeList *node_list_each( NodeList *self, void (*callback_func)( Node *node ) )
{
	NodeList *next;
	
	next = self;
	
	while(next) {
		callback_func( next->node );
		next = next->next;
	}
	return self;
}

