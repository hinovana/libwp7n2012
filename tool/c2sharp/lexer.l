%{
#include <stdlib.h>
#include <string.h>
#include "hoge.h"
#include "parse.h"

#define ECHO /* do nothing */
#define YY_NO_INPUT

extern unsigned int global_line;

int yywrap(void) {
	return 1;
}
%}
%start LINE_DOC_COMMENT LINE_DOC_COMMENT_SUMMARY LINE_DOC_COMMENT_DESCRIPTION LINE_COMMENT MULTILINE_COMMENT LINE_CSHARP_CODE MULTILINE_CSHARP_CODE IFDEF
%%
<INITIAL>"{"			return TOKEN_LC;
<INITIAL>"}"			return TOKEN_RC;
<INITIAL>":"			return TOKEN_COLON;
<INITIAL>";"			return TOKEN_SEMICOLON;
<INITIAL>"struct"		return TOKEN_STRUCT;
<INITIAL>"typedef"		return TOKEN_TYPEDEF;
<INITIAL>"signed"		return TOKEN_SIGNED;
<INITIAL>"unsigned"		return TOKEN_UNSIGNED;
<INITIAL>"char"			return TOKEN_CHAR;
<INITIAL>"int"			return TOKEN_INT;
<INITIAL>"short"		return TOKEN_SHORT;
<INITIAL>"\r"			;
<INITIAL>"\n"			{
	++global_line;
}
<INITIAL>0|[1-9][0-9]*  {
	int temp;
	sscanf( yytext, "%d", &temp );
	yylval.int_value = temp;
	return LITERAL_NUM;
}
<INITIAL>[a-zA-Z_][a-zA-Z0-9_]* {
	yylval.identifier = strdup( yytext );
	return IDENTIFIER;
}
<INITIAL>"///"			{
	yylval.doc_comment = malloc(sizeof(DocComment));
	yylval.doc_comment->summary = NULL;
	yylval.doc_comment->description = NULL;
	BEGIN LINE_DOC_COMMENT;
}
<LINE_DOC_COMMENT>"<Summary>" {
	yylval.doc_comment->summary = malloc(1);
	yylval.doc_comment->summary[0] = '\0';
	BEGIN LINE_DOC_COMMENT_SUMMARY;
}
<LINE_DOC_COMMENT>"<Description>" {
	yylval.doc_comment->description = malloc(1);
	yylval.doc_comment->description[0] = '\0';
	BEGIN LINE_DOC_COMMENT_DESCRIPTION;
}
<LINE_DOC_COMMENT_SUMMARY>. {
	size_t len = strlen(yylval.doc_comment->summary) + 1 + yyleng;
	yylval.doc_comment->summary = realloc( yylval.doc_comment->summary, len );
	strncat( yylval.doc_comment->summary, yytext, yyleng );
}
<LINE_DOC_COMMENT_SUMMARY>"</Summary>" {
	BEGIN LINE_DOC_COMMENT;
}
<LINE_DOC_COMMENT_DESCRIPTION>. {
	size_t len = strlen(yylval.doc_comment->description) + 1 + yyleng;
	yylval.doc_comment->description = realloc( yylval.doc_comment->description, len );
	strncat( yylval.doc_comment->description, yytext, yyleng );
//	fprintf( stderr, "%d, %s\n", len, yylval.doc_comment->description );
}
<LINE_DOC_COMMENT_DESCRIPTION>"</Description>" {
	BEGIN LINE_DOC_COMMENT;
}
<LINE_DOC_COMMENT>"\n"		{
	++global_line;
	BEGIN INITIAL;
	return DOC_COMMENT;
}
<INITIAL>"#"		{
	BEGIN LINE_COMMENT;
}
<INITIAL>"//"			{
	BEGIN LINE_COMMENT;
}
<LINE_COMMENT>.			;
<LINE_COMMENT>"\n"		{
	++global_line;
	BEGIN INITIAL;
}
<INITIAL>"/*"			BEGIN MULTILINE_COMMENT;
<MULTILINE_COMMENT>.	;
<MULTILINE_COMMENT>"*/"	{
	BEGIN INITIAL;
}
<INITIAL>"#ifdef"	{
	BEGIN IFDEF;
}
<IFDEF>"\n" {
	BEGIN INITIAL;
}
<IFDEF>[^\x20\t\r\n]+ {
	if( strcmp( yytext, "__csharp" ) != 0 ) {
		BEGIN INITIAL;
	} else {
		yylval.csharp_code = (char*)malloc(1);
		yylval.csharp_code[0] = '\0';
		BEGIN MULTILINE_CSHARP_CODE;
	}
}
<MULTILINE_CSHARP_CODE>"\n" {
	int len = strlen( yylval.csharp_code );
	int buffer_size = len + yyleng;
	yylval.csharp_code = (char*)realloc( yylval.csharp_code, buffer_size + 1 );
	strncat( yylval.csharp_code, yytext, yyleng );
	++global_line;
}
<MULTILINE_CSHARP_CODE>[^\r\n] {
	int len = strlen( yylval.csharp_code );
	int buffer_size = len + yyleng;
	yylval.csharp_code = (char*)realloc( yylval.csharp_code, buffer_size + 1 );
	strncat( yylval.csharp_code, yytext, yyleng );
}
<MULTILINE_CSHARP_CODE>"#endif"		{
	BEGIN INITIAL;
	return CSHARP_CODE;
}
%%
