
#include "libwp7m2008.h"
#include <stdio.h>

#define NUM_TO_SABC(x)   ((x==0)?"C":(x==1)?"B":(x==2)?"A":"S")
#define NUM_TO_BABA(x)   ((x==0)?"ŽÅ":(x==1)?"–œ":"ƒ_")
#define NAME_BUFFER_LEN  (30)


typedef struct BloodLineTree {
	struct HBloodData *blood_data;
	struct BloodLineTree *father;
	struct BloodLineTree *mother;
} BloodLineTree;


// BloodLineTree Class
BloodLineTree *blood_tree_new( ProcessMemoryTable *blood_table, DWORD blood_num );
void blood_tree_dispose( BloodLineTree *self );
void blood_tree_disp( BloodLineTree *self, WPEnvelope *env, int max_level );
void blood_tree_disp_sub( BloodLineTree *self, WPEnvelope *env, int max_level, int level, char *ext );


BloodLineTree *blood_tree_new( ProcessMemoryTable *blood_table, DWORD blood_num )
{
	BloodLineTree *self;

	self = malloc( sizeof(BloodLineTree) );
	
	self->blood_data = process_memory_table_at( blood_table, blood_num );
	
	if( self->blood_data->father_num == NULL_BLOOD_NUMBER ) {
		self->father = NULL;
	} else {
		self->father = blood_tree_new( blood_table, self->blood_data->father_num );
	}
	
	if( self->blood_data->mother_num == NULL_BLOOD_NUMBER ) {
		self->mother = NULL;
	} else {
		self->mother = blood_tree_new( blood_table, self->blood_data->mother_num );
	}
	return self;
}

void blood_tree_dispose( BloodLineTree *self )
{
	if( self->father != NULL ) {
		blood_tree_dispose( self->father );
	}
	if( self->mother != NULL ) {
		blood_tree_dispose( self->mother );
	}
	free( self );
}


void blood_tree_disp( BloodLineTree *self, WPEnvelope *env, int max_level )
{
	blood_tree_disp_sub( self->father, env, max_level, 0, "•ƒ" );
	blood_tree_disp_sub( self->mother, env, max_level, 0, "•ê" );
}

void blood_tree_disp_sub( BloodLineTree *self, WPEnvelope *env, int max_level, int level, char *prefix )
{
	HNameData  *name1, *name2;
	HFamilyLineData *family_line_data;
	char family_line_name[NAME_BUFFER_LEN];
	int i, n;
	
	if( level > max_level ) {
		return ;
	}
	
	for( i=0; i<level; ++i ) {
		printf( "%s", "    " );
	}

	if( self == NULL ) {
		printf( "%s\n", "(ŒŒ“ƒf[ƒ^–³‚µ)" );
		return;
	}
	
	name1 = hname_table_at( env->name_table, self->blood_data->name_left );
	
	if( self->blood_data->name_right == NULL_NAME_NUMBER ) {
		name2 = NULL;
	} else {
		name2 = hname_table_at( env->name_table, self->blood_data->name_right );
	}
	
	family_line_data = process_memory_table_at( env->family_line_table, self->blood_data->family_line );
	n = hfamily_line_data_get_name( family_line_data, family_line_name, NAME_BUFFER_LEN );

	if( name1 ) {
		printf( "%s%s%s(%sŒn)\n", prefix, name1->kana, name2 ? name2->kana : "", family_line_name );
	} else {
		printf( "%s(*%d)%s(%sŒn)\n", prefix, self->blood_data->name_left, name2 ? name2->kana : "", family_line_name );
	}
	blood_tree_disp_sub( self->father, env, max_level, level+1, "•ƒ" );
	blood_tree_disp_sub( self->mother, env, max_level, level+1, "•ê" );
}


static void disp_sire_data( WPEnvelope *env, DWORD sire_num )
{
	HSireData *sire_data;
	HAblData *abl_data;
	HBloodData *blood_data;
	HNameData *name1, *name2;
	HFamilyLineData *family_line_data;
	BloodLineTree *blood_tree;
	char family_line_name[NAME_BUFFER_LEN];
	int n;
	
	sire_data = process_memory_table_at( env->sire_table, sire_num );
	abl_data = process_memory_table_at( env->abl_table, sire_data->abl_num );
	blood_data = process_memory_table_at( env->blood_table, sire_data->blood_num );
	
	name1 = hname_table_at( env->name_table, blood_data->name_left );
	name2 = hname_table_at( env->name_table, blood_data->name_right );
	
	family_line_data = process_memory_table_at( env->family_line_table, blood_data->family_line );
	n = hfamily_line_data_get_name( family_line_data, family_line_name, NAME_BUFFER_LEN );
	
	blood_tree = blood_tree_new( env->blood_table, sire_data->blood_num );
	
	printf( "î•ñ(0x%04X)\n--\n", sire_num );
	printf( "%s%s(%sŒn)\n", name1->kana, name2 ? name2->kana : "", family_line_name );
	printf( "\n" );
	
	printf( "”\—Í(0x%04X)\n---\n", sire_data->abl_num  );
	printf( "SP:%2d ST:%2d —Í:%s u:%s Ÿ:%s _:%s ¸:%s Œ«:%s Œ’:%s ”n:%s\n\n",
		abl_data->speed,
		abl_data->stamina,
		NUM_TO_SABC( abl_data->power ),
		NUM_TO_SABC( abl_data->syunpatsu ),
		NUM_TO_SABC( abl_data->konzyou ),
		NUM_TO_SABC( abl_data->zyuunan ),
		NUM_TO_SABC( abl_data->seishin ),
		NUM_TO_SABC( abl_data->kashikosa ),
		NUM_TO_SABC( abl_data->health ),
		NUM_TO_BABA( abl_data->babatekisei )
	);

	printf( "ŒŒ“(0x%04X)\n---\n", sire_data->blood_num );
	blood_tree_disp( blood_tree, env, 2 );
	blood_tree_dispose( blood_tree );
	printf( "\n\n" );
}



static void *xmalloc( size_t size )
{
	void *ptr;
	
	if( (ptr = malloc( size )) == NULL ) {
		fprintf( stderr, "failed malloc\n" );
		abort();
	}
	return ptr;
}

static void xfree( void *ptr )
{
	if( ptr != NULL ) {
		free( ptr );
	}
}



void run_main()
{
	WPEnvelope env;
//	HNameData *data;
	
	Setup_Envelope( &env, WP_PROCESS_NAME );
	
//	data = name_table_at( env.name_table, 20000 );
//	fprintf( stderr, "%s", data );
	disp_sire_data( &env, 0x83 );
	Dispose_Envelope( &env );
}

int main()
{
	run_main();
	
	return 0;
}

#undef NAME_BUFFER_LEN
#undef NUM_TO_SABC
#undef NUM_TO_BABA
