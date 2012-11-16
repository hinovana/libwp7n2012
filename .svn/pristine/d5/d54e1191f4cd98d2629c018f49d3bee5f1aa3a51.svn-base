%{

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
#include "hoge.h"

#define YYDEBUG 1

int yylex();
int yyerror( char const *str );

unsigned int global_line = 0;

%}

%union {
	int int_value;
	char *identifier;
	Node *node;
	DeclarationList *dec_list;
	Declaration *dec;
	char *csharp_code;
	DocComment *doc_comment;
	Specifier spec;
	Sign sign;
}

%token
	TOKEN_LF
	TOKEN_LC				"{"
	TOKEN_RC				"}"
	TOKEN_COLON				":"
	TOKEN_SEMICOLON			";"
	TOKEN_STRUCT			"struct"
	TOKEN_SIGNED			"signed"
	TOKEN_UNSIGNED			"unsigned"
	TOKEN_CHAR				"char"
	TOKEN_INT				"int"
	TOKEN_SHORT				"short"
	TOKEN_TYPEDEF			"typedef"

%token<int_value>
	LITERAL_NUM

%token<identifier>
	IDENTIFIER

%token<doc_comment>
	DOC_COMMENT

%token<csharp_code>
	CSHARP_CODE

%type<int_value>
	constant_expression

%type<node>
	struct_declarator
	expression

%type<dec_list>
	declaration_list

%type<dec>
	declaration declaration_specifiers

%type<spec>
	type_specifier

%type<sign>
	sign_specifier

%%

expression_list
	: expression
	{
		if( global_node_list == NULL ) {
			global_node_list = node_list_new( $1 );
		} else {
			node_list_add( global_node_list, $1 );
		}
	}
	| expression_list expression
	{
		node_list_add( global_node_list, $2 );
	}
;

expression
	: struct_declarator ";"
	{
		$$ = $1;
	}
	| CSHARP_CODE
	{
		$$ = csharp_node_new( $1 );
	}
;

struct_declarator
	: TOKEN_STRUCT IDENTIFIER "{"  declaration_list  "}"
	{
		$$ = cstruct_node_new( cstruct_new( $2, $4 ) );
	}
	| TOKEN_TYPEDEF TOKEN_STRUCT "{"  declaration_list  "}" IDENTIFIER
	{
		$$ = cstruct_node_new( cstruct_new( $6, $4 ) );
	}
	| TOKEN_TYPEDEF TOKEN_STRUCT IDENTIFIER "{"  declaration_list  "}" IDENTIFIER
	{
		$$ = cstruct_node_new( cstruct_new( $3, $5 ) );
	}
;

declaration_list
	: declaration
	{
		$$ = declaration_list_new( $1 );
	}
	| declaration_list declaration
	{
		$$ = declaration_list_add( $1, $2 );
	}
;

declaration
	: declaration_specifiers IDENTIFIER ";"
	{
		$1->identifier = $2;
		$1->using_nbits_opt = 0;
		$1->nbits = 0;
		$$ = $1;
	}
	| declaration_specifiers IDENTIFIER ":" constant_expression ";"
	{
		$1->identifier = $2;
		$1->using_nbits_opt = 1;
		$1->nbits = $4;
		$$ = $1;
	}
	| declaration DOC_COMMENT
	{
//		fprintf( stderr, "%s\n", $2 );
		$1->doc_comment = $2;
		$$ = $1;
	}
;

constant_expression
	: LITERAL_NUM
	{
		$$ = $1;
	}
;

declaration_specifiers
	: type_specifier 
	{
		$$ = declaration_new( SIGN_SIGNED, $1, NULL, 0, 0, NULL );
	}
	| sign_specifier type_specifier
	{
		$$ = declaration_new( $1, $2, NULL, 0, 0, NULL );
	}
;

sign_specifier
	: "signed"   { $$ = SIGN_SIGNED; }
	| "unsigned" { $$ = SIGN_UNSIGNED; }
;

type_specifier
	: "char"     { $$ = SPECIFIER_CHAR; }
	| "int"      { $$ = SPECIFIER_INT; }
	| "short"    { $$ = SPECIFIER_SHORT; }
;

%%

int strtrim(char *s) {
	int i;
	int count = 0;
	
	/* 空ポインタか? */
	if ( s == NULL ) { /* yes */
	    return -1;
	}
	
	/* 文字列長を取得する */
	i = strlen(s);
	
	/* 末尾から順に空白でない位置を探す */
	while ( --i >= 0 && s[i] == ' ' )
		count++;
	
	/* 終端ナル文字を付加する */
	s[i+1] = '\0';
	
	/* 先頭から順に空白でない位置を探す */
	i = 0;
	while ( s[i] != '\0' && s[i] == ' ' )
		i++;
	strcpy(s, &s[i]);
	
	return i + count;
}

#define INDENT_0 "\t"
#define INDENT_1 "\t"
#define INDENT_2 "\t\t"
#define INDENT_3 "\t\t\t"
#define INDENT_4 "\t\t\t\t"
#define INDENT_5 "\t\t\t\t\t"

typedef struct StructMembers {
	unsigned int field_num;
	char *member_name;
	unsigned int bit_pos;
	unsigned int nbits;
	unsigned int max_value;
	DocComment *doc_comment;
	struct StructMembers *next;
} StructMembers;


StructMembers *struct_members_new( unsigned int field_num, char* member_name, unsigned int bit_pos, unsigned int nbits, unsigned int max_value, DocComment *doc_comment )
{
	StructMembers *self;
	
	self = malloc( sizeof( StructMembers ) );
	self->field_num = field_num;
	self->member_name = member_name;
	self->bit_pos = bit_pos;
	self->nbits = nbits;
	self->max_value = max_value;
	self->doc_comment = doc_comment;
	self->next = NULL;
	return self;
}

void struct_members_dispose( StructMembers *self )
{
	StructMembers *next, *temp;

	next = self;
	
	while( next != NULL ) {
		temp = next;
		next = next->next;
		free( temp );
	}
}

StructMembers *struct_members_add( StructMembers *self, unsigned int field_num, char* name, unsigned int bit_pos, unsigned int nbits, unsigned int max_value, DocComment *doc_comment )
{
	StructMembers *next;
	
	next = self;
	
	while( next ) {
		if( next->next == NULL ) {
			next->next = struct_members_new( field_num, name, bit_pos, nbits, max_value, doc_comment );
			break;
		}
		next = next->next;
	}
	return self;
}

int struct_members_each( StructMembers *self, char* struct_tag, void *ptr, int (*callback_func)( char* struct_tag, StructMembers *member, void *ptr ) )
{
	StructMembers *next;
	
	next = self;
	
	while( next ) {
		if( callback_func( struct_tag, next, ptr ) ) {
			return -1;
		}
		next = next->next;
	}
	return 0;
}

static int put_array_line( char* struct_tag, StructMembers *member, void *ptr )
{
	char buff[4096];
	
	my_string_sprintfln( ((myString*)ptr), buff,
		INDENT_3 "new DataStructPropertyInfo( typeof(%s).GetProperty(\"%s\"), %d, %u, \"%s\", \"%s\" ),",
		struct_tag,
		member->member_name,
		member->nbits,
		member->max_value,
		member->doc_comment->summary,
		member->doc_comment->description
	);
//	fprintf( stderr, "%s\n", struct_tag );
	
	return 0;
}

static int put_encode_line( char* struct_tag, StructMembers *member, void *ptr )
{
	char buff[1024];
	
	my_string_sprintfln( ((myString*)ptr), buff,
		INDENT_3 "data[%d] = data[%d] | ( this.%s << %d ) ;",
		member->field_num,
		member->field_num,
		member->member_name,
		member->bit_pos
	);
	return 0;
}


void cstruct_c2sharp( myString *str, FILE *file, CStruct *cstruct )
{
	DeclarationList *next;
	unsigned int bit_pos, byte_pos, n, member_len, get_mask, set_mask, max;
	StructMembers *members;
	char buff[5000];
	int i;
	
	my_string_sprintfln( str, buff, INDENT_1 "[StructLayout(LayoutKind.Explicit)]" );
	my_string_sprintfln( str, buff, INDENT_1 "public struct %s : DatastructInterface {", cstruct->identifier );

	next = cstruct->list;
	bit_pos = 0;
	byte_pos = 0;
	member_len = 0;
	members = NULL;
	
	while( next ) {
		if( bit_pos > 32 ) {
			fprintf( stderr, "構造体が32bit長になっていません" );
			fprintf( stderr, "%s : %s %d %d", cstruct->identifier, next->declaration->identifier, byte_pos, bit_pos );
			abort();
		}
		
		if( bit_pos == 32 ) {
			byte_pos++;
			bit_pos = 0;
			member_len = 0;
		}
		
		if( bit_pos == 0 ) {
			my_string_sprintfln( str, buff, INDENT_2 "// %d byte data", byte_pos * 4 );
			my_string_sprintfln( str, buff, INDENT_2 "[FieldOffset(%d)] private UInt32 __bitfield%d;", byte_pos * 4, byte_pos );
		}
		
		switch( next->declaration->specifier )
		{
		case SPECIFIER_CHAR:
			n = 8;
			break;
		case SPECIFIER_SHORT:
			n = 16;
			break;
		case SPECIFIER_INT:
			n = 32;
			break;
		default:
			fprintf( stderr, "bag1" );
			abort();
		}

		if( next->declaration->using_nbits_opt ) {
			n = next->declaration->nbits;
		}
		
		if( n == 32 ) {
			get_mask = 0xffffffff;
			set_mask = ~0xffffffff;
			max = 0xffffffff;
		} else {
			get_mask = ((int)(pow( 2, n )) - 1);
			set_mask = ~(((int)(pow( 2, n )) - 1) << bit_pos);
			max = ((int)(pow( 2, n ))) - 1;
		}
		
		strtrim( next->declaration->doc_comment->summary );
		
		if( members == NULL ) {
			members = struct_members_new( 
				byte_pos,
				next->declaration->identifier,
				bit_pos,
				n,
				max,
				next->declaration->doc_comment
			);
		} else {
			members = struct_members_add( 
				members,
				byte_pos,
				next->declaration->identifier,
				bit_pos,
				n,
				max,
				next->declaration->doc_comment
			);
		}
		my_string_sprintfln( str, buff, INDENT_2 "/// <summary>" );
		my_string_sprintfln( str, buff, INDENT_2 "/// %sの最大値", next->declaration->identifier );
		my_string_sprintfln( str, buff, INDENT_2 "/// </summary>" );
		my_string_sprintfln( str, buff, INDENT_2 "public const UInt32 %s_MAXVALUE = 0x%08x; // %u", next->declaration->identifier, max, max );

		my_string_sprintfln( str, buff, INDENT_2 "/// <summary>" );
		if( strlen( next->declaration->doc_comment->summary )  ) {
			my_string_sprintfln( str, buff, INDENT_2 "/// %s", next->declaration->doc_comment->summary );
		} else {
			my_string_sprintfln( str, buff, INDENT_2 "/// %s", next->declaration->identifier );
		}
		my_string_sprintfln( str, buff, INDENT_2 "/// </summary>" );
		
		my_string_sprintfln( str, buff, INDENT_2 "public UInt32 %s {", next->declaration->identifier );
		my_string_sprintfln( str, buff, INDENT_3 "get { return ( this.__bitfield%d >> %d ) & 0x%08x;  }", byte_pos, bit_pos, get_mask );
		my_string_sprintfln( str, buff, INDENT_3 "set {" );
		my_string_sprintfln( str, buff, INDENT_4 "if( value > %s_MAXVALUE )", next->declaration->identifier );
		my_string_sprintfln( str, buff, INDENT_5 "throw new ArgumentException(\"最大値を超えてます(0-%u)\");", max );
		my_string_sprintfln( str, buff, INDENT_4 "this.__bitfield%d = ( this.__bitfield%d & 0x%08x ) | ( value << %d );", byte_pos, byte_pos, set_mask, bit_pos );
		my_string_sprintfln( str, buff, INDENT_3 "}" );
		my_string_sprintfln( str, buff, INDENT_2 "}" );

		
		bit_pos += n;
		member_len++;
		next = next->next;
	}

	if( bit_pos != 32 ) {
		fprintf( stderr, "構造体が32bit長になっていません2\n" );
		fprintf( stderr, "%s\n\n", cstruct->identifier );
		fprintf( stderr, "%s\n", str->str );
		exit(-1);
	}
	

	my_string_sprintfln( str, buff, INDENT_2 "/// <summary>" );
	my_string_sprintfln( str, buff, INDENT_2 "/// プロパティのリスト" );
	my_string_sprintfln( str, buff, INDENT_2 "/// </summary>" );
	my_string_sprintfln( str, buff, INDENT_2 "public static DataStructPropertyInfo[][] Properties = new DataStructPropertyInfo[][] {" );
	{
		StructMembers *nextMember;
		size_t bit_pos = 0;
		
		nextMember = members;
		
		while( nextMember ) {
			if( bit_pos == 0 ) {
				my_string_sprintfln( str, buff, INDENT_3 "new DataStructPropertyInfo[]{" );
			}
			
			my_string_sprintfln( str, buff,
				INDENT_4 "new DataStructPropertyInfo( typeof(%s).GetProperty(\"%s\"), %d, %u, \"%s\", \"%s\" ),",
				cstruct->identifier,
				nextMember->member_name,
				nextMember->nbits,
				nextMember->max_value,
				nextMember->doc_comment->summary,
				nextMember->doc_comment->description
			);
			
			bit_pos += nextMember->nbits;
			if( bit_pos == 32 ) {
				my_string_sprintfln( str, buff, INDENT_3 "}," );
				bit_pos = 0;
			}
			nextMember = nextMember->next;
		}
	}
//	struct_members_each( members, cstruct->identifier, str, put_array_line );
	my_string_sprintfln( str, buff, INDENT_2 "};" );
	
	my_string_sprintfln( str, buff, INDENT_2 "/// <summary>" );
	my_string_sprintfln( str, buff, INDENT_2 "/// 構造体をメモリに書き込むためのUInt32配列にデコードする" );
	my_string_sprintfln( str, buff, INDENT_2 "/// </summary>" );
	my_string_sprintfln( str, buff, INDENT_2 "public UInt32[] Decode() {" );
	my_string_sprintfln( str, buff, INDENT_3 "var data = new UInt32[%d];", byte_pos + 1 );

	struct_members_each( members, cstruct->identifier, str, put_encode_line );

	my_string_sprintfln( str, buff, INDENT_3 "return data;" );
	my_string_sprintfln( str, buff, INDENT_2 "}" );
	
	my_string_sprintfln( str, buff, INDENT_2 "/// <summary>" );
	my_string_sprintfln( str, buff, INDENT_2 "/// 構造体をメモリに書き込むためのUInt32配列にする" );
	my_string_sprintfln( str, buff, INDENT_2 "/// </summary>" );
	my_string_sprintfln( str, buff, INDENT_2 "public UInt32[] ToArray(){" );
	my_string_sprintfln( str, buff, INDENT_3 "return this.Decode();" );
	my_string_sprintfln( str, buff, INDENT_2 "}" );
	my_string_sprintfln( str, buff, INDENT_2 "public static explicit operator UInt32[]( %s obj ){", cstruct->identifier  );
	my_string_sprintfln( str, buff, INDENT_3 "return obj.ToArray();" );
	my_string_sprintfln( str, buff, INDENT_2 "}" );

	my_string_sprintfln( str, buff, INDENT_2 "/// <summary>" );
	my_string_sprintfln( str, buff, INDENT_2 "/// UInt32配列を構造体にエンコードする" );
	my_string_sprintfln( str, buff, INDENT_2 "/// </summary>" );
	my_string_sprintfln( str, buff, INDENT_2 "public void Encode( UInt32[] data ) {" );
	my_string_sprintfln( str, buff, INDENT_3 "if( data.Length != %d )", byte_pos + 1 );
	my_string_sprintfln( str, buff, INDENT_4 "throw new ArgumentException(String.Format(\"期待するサイズと異なるサイズの配列です({0} for %d)\",data.Length));", byte_pos + 1 );
	for( i=0; i<byte_pos + 1 ; ++i ) {
		my_string_sprintfln( str, buff, INDENT_3 "this.__bitfield%d = data[%d];", i, i );
	}
	my_string_sprintfln( str, buff, INDENT_2 "}", cstruct->identifier );
	
	my_string_sprintfln( str, buff, INDENT_2 "/// <summary>" );
	my_string_sprintfln( str, buff, INDENT_2 "/// 構造体のサイズ" );
	my_string_sprintfln( str, buff, INDENT_2 "/// </summary>" );
	my_string_sprintfln( str, buff, INDENT_2 "public const UInt32 __SIZE__ = sizeof(UInt32) * %d;", byte_pos + 1 );
	my_string_sprintfln( str, buff, INDENT_1 "}" );
}


void eval_node( Node *node )
{
	myString *str;
	char buff[1024];
	
	str = my_string_new("");
	
	switch( node->type )
	{
	case NODE_CSTRUCT:
		cstruct_c2sharp( str, stdout, node->u.cstruct );
		break;
		
	case NODE_CS_CODE:
		my_string_sprintfln( str, buff, "%s", node->u.cs_code );
		break;
	
	default:
		fprintf( stderr, "[BUG] unknown node\n" );
		abort();
	}

	fprintf( stdout, "%s", str->str );
	fflush( stdout );
	my_string_dispose( str );
}

void usage()
{
	fprintf( stderr, "c2sharp FILE\n" );
}

int yyerror(char const *str)
{
	extern char *yytext;
	fprintf(stderr, "parser error near %s\n", yytext);
	fprintf(stderr, "global_line .. %d\n", global_line );
	return 0;
}

int main( int argc, char** argv )
{
	extern int yyparse(void);
	extern FILE *yyin;

	if( argc == 1 ) {
		usage();
		return -1;
	}
	
	if( (yyin = fopen( argv[1], "rb" )) == NULL ) {
		fprintf( stderr, "%s file not found ..\n", argv[1] );
		usage();
		return -1;
	}
	if( yyparse() ) {
		fprintf(stderr, "error\n");
		exit(-1);
	}
	node_list_each( global_node_list, eval_node );
	
	return 0;
}
