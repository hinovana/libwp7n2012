
#include "libwp7m2008.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

#define KOEI_CODE_LENGTH  (256)

static char *KOEI_CODE_TABLE[KOEI_CODE_LENGTH] = {
	"\x81\x40", "\x83\x40", "\x83\x41", "\x83\x42", "\x83\x43", "\x83\x44",
	"\x83\x45", "\x83\x46", "\x83\x47", "\x83\x48", "\x83\x49", "\x83\x4a",
	"\x83\x4b", "\x83\x4c", "\x83\x4d", "\x83\x4e", "\x83\x4f", "\x83\x50",
	"\x83\x51", "\x83\x52", "\x83\x53", "\x83\x54", "\x83\x55", "\x83\x56",
	"\x83\x57", "\x83\x58", "\x83\x59", "\x83\x5a", "\x83\x5b", "\x83\x5c",
	"\x83\x5d", "\x83\x5e", "\x83\x5f", "\x83\x60", "\x83\x61", "\x83\x62",
	"\x83\x63", "\x83\x64", "\x83\x65", "\x83\x66", "\x83\x67", "\x83\x68",
	"\x83\x69", "\x83\x6a", "\x83\x6b", "\x83\x6c", "\x83\x6d", "\x83\x6e",
	"\x83\x6f", "\x83\x70", "\x83\x71", "\x83\x72", "\x83\x73", "\x83\x74",
	"\x83\x75", "\x83\x76", "\x83\x77", "\x83\x78", "\x83\x79", "\x83\x7a",
	"\x83\x7b", "\x83\x7c", "\x83\x7d", "\x83\x7e", "\x83\x80", "\x83\x81",
	"\x83\x82", "\x83\x83", "\x83\x84", "\x83\x85", "\x83\x86", "\x83\x87",
	"\x83\x88", "\x83\x89", "\x83\x8a", "\x83\x8b", "\x83\x8c", "\x83\x8d",
	"\x83\x8e", "\x83\x8f", "\x83\x90", "\x83\x91", "\x83\x92", "\x83\x93",
	"\x83\x94",
	"\xb6", "\xb9", "\x30", "\x31", "\x32", "\x33", "\x34", "\x35", "\x36",
	"\x37", "\x38", "\x39", "\x30", "\x31", "\x32", "\x33", "\x34", "\x35",
	"\x36", "\x37", "\x38", "\x39", "\x41", "\x42", "\x43", "\x44", "\x45",
	"\x46", "\x47", "\x48", "\x49", "\x4a", "\x4b", "\x4c", "\x4d", "\x4e",
	"\x4f", "\x50", "\x51", "\x52", "\x53", "\x54", "\x55", "\x56", "\x57",
	"\x58", "\x59", "\x5a", "\x61", "\x62", "\x63", "\x64", "\x65", "\x66",
	"\x67", "\x68", "\x69", "\x6a", "\x6b", "\x6c", "\x6d", "\x6e", "\x6f",
	"\x70", "\x71", "\x72", "\x73", "\x74", "\x75", "\x76", "\x77", "\x78",
	"\x79", "\x7a", "\x20",
	"\x27", "\x2e", "\x87\x54", "\x87\x55", "\x87\x56", "\x87\x57",
	"\x87\x58", "\x87\x59", "\x87\x5a", "\x87\x5b", "\x87\x5c", "\x87\x5d",
	"\x87\x40", "\x87\x41", "\x87\x42", "\x87\x43", "\x87\x44", "\x87\x45",
	"\x87\x46", "\x87\x47", "\x87\x48", "\x81\x40", "\x91\xe6", "\x88\xea",
	"\x93\xf1", "\x8e\x4f", "\x8e\x6c", "\x8c\xdc", "\x98\x5a", "\x8e\xb5",
	"\x94\xaa", "\x8b\xe3", "\x8f\x5c", "\x88\xeb", "\x93\xf3", "\x8e\x51",
	"\x8f\x45", "\x81\x99", "\xb1", "\xb1", "\xb1", "\xb1", "\xb1",
	"", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
	"", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
	"\xb1", "\xb1", "\xb1", "\xb1", "\xb1", "\xb1", "\xb1", "\xb1", "\xb1",
	"\xb1", "\xb1", "\xb1", "\xb1", "\xb1", "\xb1", "\xb1", "\xb1", "\x2d",
	"\x81\x5b", "\x96\xb3", 
};

void *xmalloc( size_t size )
{
	void *ptr;
	
	if( (ptr = malloc( size )) == NULL ) {
		fprintf( stderr, "failed malloc\n" );
		abort();
	}
	return ptr;
}

void xfree( void *ptr )
{
	if( ptr != NULL ) {
		free( ptr );
	}
}


static int strcmp_i( const char * str1, const char * str2 )
{
	int result, i;

	if( strlen( str1 ) != strlen( str2 ) ) {
		return 1;
	}
	
	result = 0;
	
	for( i=0; i < (int)strlen(str1); ++i ) {
		if( tolower( str1[i] ) != tolower( str2[i] ) ) {
			result = 1;
			break;
		}
	}
	return result;
}

static DWORD get_process_id_by_name( const char *process_name )
{
	DWORD          dwProcessId;
	HANDLE         hSnapshot;
	PROCESSENTRY32 pe;
	
	hSnapshot = CreateToolhelp32Snapshot( TH32CS_SNAPPROCESS, 0 );
	dwProcessId = 0;

	if( hSnapshot == INVALID_HANDLE_VALUE ) {
		return 0;
	}
	
	pe.dwSize = sizeof(PROCESSENTRY32);
	Process32First(hSnapshot, &pe);
	
	do {
		if( strcmp_i( pe.szExeFile, process_name ) == 0 ) {
			dwProcessId = pe.th32ProcessID;
			break;
		}
	} while( Process32Next( hSnapshot, &pe ) );
	
	CloseHandle( hSnapshot );
	
	return dwProcessId;
}


ProcessMemory* WINAPI process_memory_new( DWORD processId )
{
	ProcessMemory *self = xmalloc( sizeof(ProcessMemory) );

	self->processId = processId;

	if( ( self->handle = OpenProcess( PROCESS_ALL_ACCESS, TRUE, processId )) == NULL ) {
		XABORT( "failed -- OpenProcess" );
	}
	return self;
}

void WINAPI process_memory_dispose( ProcessMemory *self )
{
	CloseHandle( self->handle );
	xfree( self );
}

BOOL WINAPI process_memory_write( ProcessMemory *self, DWORD address, DWORD size, void* buffer )
{
	DWORD writeByte = 0;

	return WriteProcessMemory( self->handle, (void*)address, buffer, size, &writeByte );
}

BOOL WINAPI process_memory_read( ProcessMemory *self, DWORD address, DWORD size, void* buffer )
{
	DWORD readByte = 0;

	return ReadProcessMemory( self->handle, (void*)address, buffer, size, &readByte );
}

ProcessMemoryTable* WINAPI process_memory_table_new( ProcessMemory *ps, DWORD pointer_address, DWORD record_size, DWORD record_length )
{
	ProcessMemoryTable *self = xmalloc( sizeof(ProcessMemoryTable) );
	DWORD data_address;
	size_t size;
	
	size = record_size * record_length;
	
	self->ps = ps;
	self->data = xmalloc( size );
	self->data_size = size;
	self->pointer_address = pointer_address;
	self->record_size = record_size;
	self->record_length = record_length;
	
	if( process_memory_read( ps, pointer_address, sizeof(DWORD), &data_address ) == FALSE ) {
		XABORT( "failed -- process_memory_read" );
	}
	if( process_memory_read( ps, data_address, size, self->data ) == FALSE ) {
		XABORT( "failed -- process_memory_read" );
	}
	
	return self;
}

void WINAPI process_memory_table_dispose( ProcessMemoryTable *self )
{
	xfree( self->data );
	xfree( self );
}

void* WINAPI process_memory_table_at( ProcessMemoryTable *self, DWORD num )
{
	return self->data + ( self->record_size * num );
}

BOOL WINAPI process_memory_table_commit( ProcessMemoryTable *self )
{
	DWORD data_addres;
	
	if( process_memory_read( self->ps, self->pointer_address, sizeof(DWORD), &data_addres ) == FALSE ) {
		XABORT( "failed -- process_memory_read" );
	}
	return process_memory_write( self->ps, data_addres, self->data_size, self->data );
}

BNode* WINAPI bnode_new( int value, void *data )
{
	BNode *self;
	
	self = xmalloc( sizeof(BNode) );
	self->value = value;
	self->data = data;
	self->left = NULL;
	self->right = NULL;
	
	return self;
}

void WINAPI bnode_insert( BNode *self, int value, void *data )
{
	if( self->value > value ) {
		if( self->left != NULL ) {
			bnode_insert( self->left, value, data );
		} else {
			self->left = bnode_new( value, data );
		}
	} else if( self->value < value ) {
		if( self->right != NULL ) {
			bnode_insert( self->right, value, data );
		} else {
			self->right = bnode_new( value, data );
		}
	} else {
		self->data = data;
	}
}

void* WINAPI bnode_find( BNode *self, int value )
{
	if( self->value > value ) {
		if( self->left == NULL ) {
			return NULL;
		}
		return bnode_find( self->left, value );
	} else if( self->value < value ) {
		if( self->right == NULL ) {
			return NULL;
		}
		return bnode_find( self->right, value );
	}
	return self->data;
}

void WINAPI bnode_dispose( BNode *self, void (WINAPI *free_func)(void*) )
{
	if( self == NULL ) {
		return;
	}
	bnode_dispose( self->left, free_func );
	bnode_dispose( self->right, free_func );
	
	free_func( self->data );
	xfree( self );
}

HNameData* WINAPI name_data_new( int id, char *kana, char *english )
{
	HNameData *self;
	
	self = xmalloc( sizeof(HNameData) );
	self->id = id;
	self->kana = strdup( kana );
	self->english = strdup( english );
	
	return self;
}

void WINAPI name_data_dispose( HNameData *self )
{
	xfree( self->kana );
	xfree( self->english );
	xfree( self );
}

int WINAPI koei_codes_to_array( int *koei_codes, size_t len, char *buffer, size_t buffer_len )
{
	size_t i;
	
	memset( buffer, '\0', buffer_len );
	
	for( i=0; i<len; ++i ) {
		if( koei_codes[i] == 0 ) {
			break;
		}
		strcat( buffer, KOEI_CODE_TABLE[ koei_codes[i] ] );
	}
	return i == 0 ? i : i--;
}


void hname_table_new_sub( HNameTable *self, unsigned char *data_table, DWORD table_size );

HNameTable* WINAPI hname_table_new( ProcessMemory *ps )
{
	HNameTable *self;
	DWORD table_size;
	DWORD data_address;
	unsigned char *data_table;
	
	if( process_memory_read( ps, HORSE_NAME_TABLE_SIZE_ADDRESS, sizeof(DWORD), &table_size ) == FALSE ) {
		XABORT( "failed -- process_memory_read" );
	}
	if( process_memory_read( ps, HORSE_NAME_TABLE_POINTER_ADDRESS, sizeof(DWORD), &data_address ) == FALSE ) {
		XABORT( "failed -- process_memory_read" );
	}
	data_table = xmalloc( table_size );
	
	if( process_memory_read( ps, data_address, table_size, data_table ) == FALSE ) {
		free( data_table );
		XABORT( "failed -- process_memory_read" );
	}
	self = xmalloc( sizeof(HNameTable) );
	hname_table_new_sub( self, data_table, table_size );
	xfree( data_table );
	
	return self;
}

void hname_table_new_sub( HNameTable *self, unsigned char *data_table, DWORD table_size )
{
#define IS_KANA(x)  ((x>=0xB6&&x<=0xC4)||(x>=0x01&&x<=0x56)||(x==0xFE))
#define IS_ENG(x)   ((x>=0x57&&x<=0x9E)||(x>=0x9F&&x<=0xA1)||(x>=0xAC&&x<=0xB4)||(x==0xFD))

	unsigned char *ptr;
	char buff[30];
	int name[30];
	int n, i;
	
	ptr = data_table;
	i = 0;
	
	do {
		HNameData name_data;
		name_data.id = i;

		n = 0;
		
		do {
			// カナ部分
			if( (DWORD)(ptr - data_table) >= table_size ) {
				XABORT("馬名テーブルが解析できませんでした");
			}
			if( !IS_KANA(*ptr) && !IS_ENG(*ptr) ) {
				XABORT("馬名テーブルが解析できませんでした(カナ)");
			}
			name[n] = *ptr++;
			
			if( !IS_KANA(*ptr) ) {
				koei_codes_to_array( name, n+1, buff, 30 );
				name_data.kana = strdup( buff );
				break;
			}
			++n;
		} while(1);
		
		n = 0;
		
		do {
			// 英語部分
			if( (DWORD)(ptr - data_table) >= table_size ) {
				XABORT("馬名テーブルが解析できませんでした");
			}
			if( !IS_KANA(*ptr) && !IS_ENG(*ptr) ) {
				XABORT("馬名テーブルが解析できませんでした(漢字)");
			}
			name[n] = *ptr++;
			
			if( !IS_ENG(*ptr) ) {
				koei_codes_to_array( name, n+1, buff, 30 );
				name_data.english = strdup( buff );
				break;
			}
			++n;
		} while(1);
		
		self->system[ i++ ] = name_data;
		
	} while( HORSE_NAME_TABLE_SYSTEM_MAX >= i );

#undef IS_KANA
#undef IS_ENG
}

void WINAPI hname_table_dispose( HNameTable *self )
{
	int i;
	HNameData *data;
	for( i=0; i<=HORSE_NAME_TABLE_SYSTEM_MAX; ++i ) {
		if( (data = hname_table_at( self, i )) != NULL ) {
			free( data->kana );
			free( data->english );
		}
	}
	free( self );
}

HNameData* WINAPI hname_table_at( HNameTable *self, DWORD n )
{
	if( n > HORSE_NAME_TABLE_SYSTEM_MAX ) {
		return NULL;
	}
	return &(self->system[n]);
}

int WINAPI hfamily_line_data_get_name( HFamilyLineData *self, char *buffer, size_t len )
{
#define NAMES_LEN (14)
	
	int names[NAMES_LEN];
	
	names[0] = self->name_1;
	names[1] = self->name_2;
	names[2] = self->name_3;
	names[3] = self->name_4;
	names[4] = self->name_5;
	names[5] = self->name_6;
	names[6] = self->name_7;
	names[7] = self->name_8;
	names[8] = self->name_9;
	names[9] = self->name_10;
	names[10] = self->name_11;
	names[11] = self->name_12;
	names[12] = self->name_13;
	names[13] = self->name_14;
	
	return koei_codes_to_array( names, NAMES_LEN, buffer, len );

#undef NAMES_LEN
}


void WINAPI Setup_Envelope( WPEnvelope *env, char *wp7_process_name )
{
	DWORD processId;
	
	assert( ABILITY_DATA_SIZE == sizeof(HAblData) );
	assert( BLOOD_DATA_SIZE == sizeof(HBloodData) );
	assert( FAMILY_LINE_DATA_SIZE == sizeof(HFamilyLineData) );
	assert( HORSE_SIRE_DATA_SIZE == sizeof(HSireData) );
	assert( HORSE_DAM_DATA_SIZE == sizeof(HDamData) );
	assert( HORSE_RACE_DATA_SIZE == sizeof(HRaceData) );
	
	if( ( processId = get_process_id_by_name( wp7_process_name ) ) == 0 ) {
		XABORT( "FAILED .. process not found" );
	}
	
	env->ps = process_memory_new( processId );
	
	env->name_table = hname_table_new(
		env->ps
	);
	env->abl_table = process_memory_table_new(
		env->ps,
		ABILITY_POINTER_ADDRESS,
		ABILITY_DATA_SIZE,
		ABILITY_MAX
	);
	env->blood_table = process_memory_table_new(
		env->ps,
		BLOOD_POINTER_ADDRESS,
		BLOOD_DATA_SIZE,
		BLOOD_MAX
	);
	env->family_line_table = process_memory_table_new(
		env->ps,
		FAMILY_LINE_POINTER_ADDRESS,
		FAMILY_LINE_DATA_SIZE,
		FAMILY_LINE_MAX
	);
	env->sire_table = process_memory_table_new(
		env->ps,
		HORSE_SIRE_POINTER_ADDRESS,
		HORSE_SIRE_DATA_SIZE,
		HORSE_SIRE_MAX
	);
	env->dam_table = process_memory_table_new(
		env->ps,
		HORSE_DAM_POINTER_ADDRESS,
		HORSE_DAM_DATA_SIZE,
		HORSE_DAM_MAX
	);
	env->hrace_table = process_memory_table_new(
		env->ps,
		HORSE_RACE_POINTER_ADDRESS,
		HORSE_RACE_DATA_SIZE,
		HORSE_RACE_MAX
	);
}

void WINAPI Dispose_Envelope( WPEnvelope *env )
{
	process_memory_dispose( env->ps );
	hname_table_dispose( env->name_table );
	process_memory_table_dispose( env->abl_table );
	process_memory_table_dispose( env->blood_table );
	process_memory_table_dispose( env->family_line_table );
	process_memory_table_dispose( env->sire_table );
	process_memory_table_dispose( env->dam_table );
	process_memory_table_dispose( env->hrace_table );
}

