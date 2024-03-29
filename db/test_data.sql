  update medicine set name = REPLACE(name, 'Dr. Max' ,'')   
  update medicine set name = REPLACE(name, 'Dr.Max' ,'') 
    update medicine set name = LTRIM(name) 
  update medicine set [description] = '', [usage] = '', dosage = '', warning = '', active_substances = ''
  delete from medicine where name = ''

  update medicine set 
  [description] = 'Paracetamol, liečivo obsiahnuté v lieku, pôsobí proti bolesti a znižuje zvýšenú telesnú teplotu.
Liek nezhoršuje žalúdočné ťažkosti a nevyvoláva krvácanie, môžu ho užiť aj chorí s vredmi žalúdka a dvanástnika a chorí, ktorí neznášajú kyselinu acetylsalicylovú.
Liek je určený na zníženie horúčky a bolesti pri chrípke, nachladnutí a iných infekčných ochoreniach. Liek je tiež vhodný pri bolestiach rôzneho pôvodu, napr. pri bolestiach hlavy, zubov, pri bolestivej menštruácii, bolesti hrdla a bolesti pohybového ústrojenstva nezápalového pôvodu.',
usage = 'Tablety, ktoré je možné deliť aj podať rozdrvené, sa užívajú počas jedla alebo tesne pred jedlom, zapíjajú sa dostatočným množstvom tekutiny. Je nutné dodržiavať odstupy medzi jednotlivými dávkami uvedené vyššie.
Tableta sa môže rozdeliť na 2 rovnaké dávky.'
,dosage = 'Dospelí a dospievajúci (starší ako 15 rokov) s telesnou hmotnosťou viac ako 50 kg:
Podáva sa 1-2 tablety podľa potreby v časovom odstupe najmenej 4 hodiny do maximálnej dennej dávky 8 tabliet. Najvyššia jednotlivá dávka je 2 tablety. Počas dlhodobej liečby (nad 10 dní) nemá denná dávka prekročiť 5 tabliet.

Deti a dospievajúci vo veku 6 -15 rokov:
Podáva sa 1/2 tablety až 1 tableta ako jednorazová dávka. Jednotlivé dávky sa podávajú s časovým odstupom najmenej 6 hodín. Interval možno skrátiť podľa potreby na 4 hodiny, pričom nesmie byť prekročená maximálna celková denná dávka.
U detí s telesnou hmotnosťou je maximálna celková denná dávka 3 tablety (1,5 g paracetamolu).
U detí s telesnou hmotnosťou 26-40 kg je maximálna celková denná dávka 4 tablety (2 g paracetamolu).
U detí s telesnou hmotnosťou 40-50 kg je maximálna celková denná dávka 6 tabliet (3 g paracetamolu).'
, warning = 'Ak je to klinicky potrebné, paracetamol sa môže podávať počas tehotenstva, avšak má byť použitá minimálna účinná dávka po čo najkratšiu dobu a s najnižšiu možnou frekvenciou.
U dojčiacich žien pri krátkodobej liečbe a súčasnom starostlivom sledovaní dojčaťa nie je nutné prerušiť dojčenie.
U detí mladších ako 6 rokov a/alebo u detí s telesnou hmotnosťou nižšou ako 20 kg je liek kontraindikovaný.
Neužívať súbežne ďalšie lieky obsahujúce paracetamol.
Liek nesmú užívať pacienti s ťažkou formou hepatálnej insuficiencie, a/alebo akútnou hepatitídou.
Nepiť alkohol.'
,active_substances = 'paracetamol'
,producer = 'Zentiva, k.s. (CZE)'
where [name] like 'paralen%' or [name] like 'ibalgin%' or name like 'Paracet%' or name like 'ibupro%'

  update medicine set 
  [description] = 'Stabilizačná opora FUTURO zabezpečuje pevnú oporu a úľavu pri akútnych a chronických bolestiach kolena spôsobených syndrómom preťaženia a instabilitou, pri poškodenom väzive a svale, či artritíde.

Pomáha zabrániť opätovnému zraneniu. Je možné ju používať pri športe a iných pohybových aktivitách.'
  ,usage = 'Aplikuje sa priamo na postihnuté miesto'
,active_substances = ''
,producer = '3M Health Care (USA)'
where [name] like '%bandáž%' 


  update medicine set 
  [description] = 'Liečivom lieku je cetirizín dihydrochlorid. Liek je proti alergii a je určený dospelým a deťom vo veku 6 rokov a starším:

na zmiernenie nosových a očných príznakov sezónnej a celoročnej alergickej nádchy,
na zmiernenie prejavov žihľavky.'
  ,usage = 'Tablety sa prehĺtajú v celku a zapíjajú sa pohárom vody, užívajú sa nezávisle od jedla.
Tablety majú deliacu ryhu a môžu sa rozdeliť na 2 rovnaké dávky.'
  ,dosage = 'Deti vo veku 6-12 rokov: 1/2 tablety 2x denne.
Dospelí a deti staršie ako 12 rokov: 1 tableta 1x denne.

Pacienti s poruchou funkcie obličiek
Klírens kreatinínu 30-49 ml/min užíva sa 1/2 tablety 1x denne.
Klírens kreatinínu < 30 ml/min užíva sa 1/2 tablety každý druhý deň.
Deti: je nutné upraviť dávkovanie individuálne s prihliadnutím na hodnotu renálneho klírensu každého pacienta, vek a jeho hmotnosť.

Dĺžka liečby závisí od druhu, trvania a priebehu ochorenia a určuje ju lekár.'
,warning = 'Liek sa môže užívať počas tehotenstva a dojčenia s opatrnosťou.
Liek sa neodporúča pre deti mladšie ako 6 rokov pre vysoký obsah účinnej látky.
Liek je kontraindikovaný u pacientov s klírensom kreatinínu < 10 ml/min.
U pacientov s epilepsiou sa vyžaduje zvýšená opatrnosť.
Liek ovplyvňuje výsledky kožných testoch. Pred testovaním je potrebné vysadiť lieky 3 dni vopred.
Ak sa po aplikácii lieku vyskytne ospalosť alebo únava, neodporúča sa viesť vozidlá a obsluhovať stroje.
Nepiť alkohol.'
,active_substances = 'cetirizíniumdichlorid'
,producer = 'UCB Pharma Ltd. (GBR)'
where [name] like '%zodac%' or [name] like '%zyrtec%' or name like '%alerod%' or name like '%cetirizin%' or name like '%cetirizín%' or name like '%cetixin%' 


  update medicine set 
  [description] = 'Liek je dermálny krém, patrí do skupiny liekov proti kožným vírusovým ochoreniam. Používa sa na liečbu oparov na perách a tvári vyvolaných vírusom Herpes simplex v štádiu svrbenia, pálenia alebo pľuzgierikov. '
  ,usage = 'Krém sa môže používať len na kožu (dermálne použitie). Nanáša sa v tenkej vrstve tak, aby úplne pokryl celú postihnutú oblasť a polcentimetrový okraj okolitej zdravej pokožky. Pred ošetrením postihnutej oblasti a po ňom sa vždy umyjú ruky. Postihnutú oblasť netreba vystavovať zbytočnému treniu ani ju utierať uterákom, zabráni sa tak zhoršeniu a šíreniu infekcie.'
  ,dosage = 'Krém sa aplikuje hneď pri prvých prejavoch alebo príznakoch infekcie na postihnuté miesto 5x denne približne v 4-hodinových intervaloch (s výnimkou noci).
Trvanie liečby: najmenej 4 dni. Ak nenastane zlepšenie, je možné v liečbe pokračovať ďalších 6 dní. Ak pretrvávajú príznaky aj po 10 dňoch liečby, je nutné kontaktovať lekára.'
  ,warning = 'Liek možno použiť v tehotenstve a tiež počas dojčenia v prípade, ak potenciálny prínos liečby prevyšuje možné riziko.
Neodporúča sa nanášať krém na sliznicu ústnej dutiny a oka.
Liek sa neodporúča používať u pacientov s oslabeným imunitným systémom (napr. pacienti s AIDS alebo pacienti po transplantácii kostnej drene). Liečba akejkoľvek infekcie u týchto pacientov musí prebiehať pod dohľadom príslušného špecialistu.'
,active_substances = 'aciklovir'
,producer = 'GlaxoSmithKline Consumer Healthcare Czech Republik (CZE)'
where [name] like '%acyclovir%' or [name] like '%herpesin%'  or [name] like '%telviran%'  or [name] like '%zovirax%' 


  update medicine set 
  [description] = 'Zloženie zanecháva pleť hydratovanú a vyčistenú.'
  ,usage = 'Potrebné množstvo mlieka sa nanesie priame na pokožku'
  ,dosage = ''
  ,warning = ''
,active_substances = ''
,producer = 'VICHY Laboratoires (FRA)'
where [name] like '%vichy%'

  update medicine set 
  [description] = 'Výživový doplnok s kyselinou listovou, inozitolom a alfa-laktalbumínom. 

 Folát (kyselina listová):

prispieva k správnej funkcii psychiky,
prispieva k zníženiu vyčerpania a únavy,
zohráva úlohu v procese delenia buniek a prispieva k rastu zárodočných tkanív počas tehotenstva.'
  ,usage = ''
  ,dosage = 'Prípravok sa odporúča užívať v dávke 1 vrecúško 2x denne mimo hlavných jedál najlepšie s odstupom 12 hodín. Obsah vrecúška sa rozpustí v pohári vody (200ml) a vypije sa.'
  ,warning = 'Prípravok nie je vhodný pre deti do 3 rokov. Uchovávať mimo dosahu detí. Neprekračovať odporúčanú dennú dávku. Výživové doplnky nie sú náhradou bohatej a vyváženej stravy a ani zdravého životného štýlu. Obsahuje mliečne proteíny.'
,active_substances = 'alfa-laktalbumín , kyselina listová - Folát (vitamín B9) , myo-inozitol'
,producer = 'Nutrilinea S.r.l. (ITA)'
where [name] like '%inofolic%' or [name] like '%lejdy%'or [name] like '%miovar%' or [name] like '%myosit%'or [name] like '%natifem%'or [name] like '%nosifol%'or [name] like '%yarilo%'

  update medicine set 
  [description] = 'určená na fixáciu obväzov,
na pripevnenie sond, kanýl, cievok, katétrov a pod.,
vhodná pre normálne citlivú pokožku.'
  ,usage = 'Pri použití dbať na to, aby pokožka bola čistá a suchá. Po odstrihnutí náplasti primeranej dĺžky použiť na fixáciu podľa potreby.'
  ,dosage = ''
  ,warning = ''
,active_substances = ''
,producer = '3M Česko, spol. s r.o. (CZE)'

where [name] like '%náplas%' 

  update medicine set 
  [description] = 'Zloženie s obsahom originálneho prírodného Tea Tree Oil. Bez parabénov. Gél je vhodný k dennému používaniu pre všetky typy pokožky a na upokojenie bežných drobných poškodení. Telo bude po aplikácii svieže.'
  ,usage = 'Naniesť potrebné množstvo priamo na pokožku'
  ,dosage = ''
  ,warning = ''
,active_substances = ''
,producer = 'Australian Bodycare Continental (DNK)'
where [name] like '%aBC tea tree oi%'

  update medicine set 
  [description] = 'Vkladacie plienky Abri San sú vhodné pre strednú a ťažkú inkontinenciu, predovšetkým u mobilných pacientov, rovnako pre mužov i ženy. Indikujú sa výlučne podľa stupňa postihnutia, bez ohľadu na rozmery pacienta. Fixujú sa pomocou fixačných nohavičiek. Bezpečnosť, kvalita, maximálne pohodlie užívateľa a ohľaduplnosť k životnému prostrediu sú kľúčovými prvkami pri vývoji plienok v Abene. Všetko s maximálnou snahou neustále zlepšovať kvalitu života.
  Najpodstatnejšie vlastnosti:

vkladacie plienky sú plne priedušné,
prémiová kvalita, bezpečnosť a pohodlie pre užívateľa,
ako jediné na svete z pomôcok pre dospelých sú ocenené Severskou ekoznámkou SWAN, ktorá garantuje okrem ohľaduplnosti k životnému prostrediu aj maximálnu kvalitu výrobku,
na vonkajšej strane plienky je zreteľný indikátor vlhkosti, ktorý jasne signalizuje nutnosť výmeny plienky,
plienky s "Odour system"-om - superabsorbent s pohlcovaním nepríjemných pachov,
vysoká sacia schopnosť, rozvodové kanáliky, dvojité absorpčné jadro, Top-dry a systém prepracovaných bariér sú samozrejmosťou.'
  ,usage = 'Vkladacie plienky sa fixujú fixačnými nohavičkami. Plienky majú indikátor vlhkosti, ktorý upozorňuje, kedy je potrebná výmena plienky za novú. Odporúča sa výmena po max. 8 hodinách počas dňa alebo noci, t.j. min. 3x denne.'
  ,dosage = ''
  ,warning = ''
,active_substances = ''
,producer = 'ABENA A/S (DNK)'
where [name] like '%abena%' or [name] like '%zyrtec%' 

  update medicine set 
  [description] = 'čaj'
  ,usage = 'Lyžicu čajoviny na 2 dcl vriacej vody. Lúhovať 10 – 15 minút.'
  ,dosage = ''
  ,warning = ''
,active_substances = ''
,producer = 'AGROKARPATY, s.r.o. Plavnica (SVK)'
where [name] like '%agrokarpaty%' or [name] like '%čaj%' 

   update medicine set 
  [description] = 'Výživový doplnok  s obsahom omega 3 mastných kyselín. 

EPA a DHA prispievajú k správnej funkcii srdca a tým podporujú udržanie jeho zdravia. Priaznivý účinok sa dosiahne pri dennom príjme 250 mg EPA a DHA , teda v dávke nachádzajúcej sa už v 1 kapsule Omega ADVANCE.
DHA prispieva k udržaniu správnej činnosti mozgu. Priaznivý účinok sa dosiahne pri dennom príjme 250 mg DHA.
DHA prispieva udržaniu dobrého zraku. Priaznivý účinok sa dosiahne pri pri dennom príjme 250 mg DHA.
Aktívne látky v 1 kapsule:  Rybí olej MEG-3 500 mg z toho:

Omega 3 300 mg
EPA 165 mg
DHA 110 mg'
  ,usage = 'Užívanie a dávkovanie:

Dospelí: 1 – 2 kapsuly denne.
Deti: 1 kapsula denne.
Dostatočne zapite'
  ,dosage = ''
  ,warning = 'Nie je určené pre deti do 3 rokov. Neužívajte pri známej precitlivenosti na niektorú zo zložiek produktu. Neprekračujte odporúčané dávkovanie. Nie je určené ako náhrada pestrej stravy. Skladujte v tme a suchu pri teplote do 25°C. Ukladajte mimo dosahu detí.'
,active_substances = 'kyselina dokozahexaénová (DHA) , kyselina eikozapentaénová (EPA) , omega-3-mastné kyseliny (nešpecifikované) , rybí olej (EPA, DHA)'
,producer = 'ADVANCE nutraceutics s.r.o. (CZE)'
where [name] like '%advance%' or [name] like '%omega%'

 
  update medicine set 
  [description] = 'Výživový doplnok, obsahuje esenciálne aminokyseliny, vitamíny a minerály.
Vitamín C a Zinok prispievajú k správnemu fungovaniu imunitného systému.'
  ,usage = 'Odporúčané dávkovanie: dospelí užívajú 1–2 tablety denne s jedlom
Výživový doplnok sa užíva niekoľkých hodín pred alebo po užití iných liekov. 
O užívaní dlhšom ako šesť mesiacov sa poraďte s lekárom. '
  ,dosage = ''
  ,warning = 'Nevhodné pre deti, tehotné a dojčiace ženy. Osoby s níz­kobielkovinovou diétou by mali konzultovať užívanie doplnku s lekárom. Uchovávajte pri teplote 15–25 °C, mimo dosah malých detí. Ustanovená odporúčaná denná dávka sa nesmie presiahnuť. Výživový doplnok sa ne­smie používať ako náhrada rozmanitej stravy.'
,active_substances = ''
,producer = 'Jamieson Laboratories (CAN)'
where [name] like '%jamieson%'


  update medicine set 
  [description] = 'Obsahuje vitamíny, upokojuje pokožku, regeneruje, poradí si i so začervenaním a povrchovými poraneniami. Vhodné pre starostlivosť o namáhanú a podráždenú pokožku.'
  ,usage = 'Aplikuje sa na čistú pokožku, dôkladne sa rozotrie.'
  ,dosage = ''
  ,warning = 'Skladovať pri teplote 15 - 25 °C, chrániť pred slnečným svetlom.'
,active_substances = ''
,producer = 'Saneca Pharmaceuticals, a.s. (SVK)'
where [name] like '%indulona%' 

  update medicine set 
  [description] = 'Prípravok po opaľovaní obsahuje aktívny enzým na opravu DNA – endonukleázu. Podobné enzýmy sa v koži vyskytujú aj prirodzene a prispievajú tak k rýchlej regenerácii kože po pobyte na slnku a slúžia ako prevencia predčasného starnutia kože.

na regeneráciu pokožky po pobyte na slnku,
vhodné na použitie aj počas horúcich slnečných dní,
príjemne chladivé,
nemastí a veľmi rýchlo sa vstrebáva,
zaisťuje intenzívnu hydratáciu a ošetrenie.'
  ,usage = 'Po pobyte na slnku sa mlieko nanáša v dostatočnom množstve na tvár a telo a jemne sa vmasíruje. Lócio nemastí a veľmi rýchlo sa vstrebáva.'
  ,dosage = ''
  ,warning = ''
,active_substances = ''
,producer = 'Nestlé Skin Health (FRA)'
where [name] like '%daylong%'  


  update medicine set 
  [description] = 'Počiatočná dojčenská mliečna výživa v prášku. Výrobok je určený na osobitnú výživu dojčiat od narodenia pokiaľ nemôžu byť dojčené. Obsahuje:

klinicky testovanú zmes oligosacharidov scGOS/lcFOS (9:1),
omega 3 mastné kyseliny DHA,
nukleotidy.
Pre výživu novorodencov a dojčiat je najprirodzenejšou a najvhodnejšou stravou, zastúpením svojich živín a ich kvalitou, materské mlieko. Nutrilon 1 by sa mal používať len na základe rady nezávislých osôb kvalifikovaných v lekárstve, výžive alebo farmácii alebo iných odborníkov zodpovedných za starostlivosť o matku a dieťa.'
  ,usage = ''
  ,dosage = 'Pre zdravie dojčiat je dôležité dodržiavať návod na prípravu i uvedené odporúčania.
Dôkladne sa umyjú ruky a všetko náčinie, ktoré sa bude používať. Čerstvá pitná voda určená pre dojčatá sa prevarí a nechá v kanvici vychladnúť asi 30 minút na približne 40 °C. Zodpovedajúce množstvo vody sa vleje do vysterilizovanej fľaše. Na dávkovanie sa použije priložená odmerka a prášok sa zarovná pomocou plastového pásika (vo vnútri obalu) na dosiahnutie presnej dávky. Prášok sa v odmerke nestláča. Do vody sa pridá zopovedajúce množstvo prášku. Fľaša sa uzatvorí a dôkladne pretrepe (najmenej 10 sekúnd), kým sa všetok prášok rozpustí. Teplota mliečnej zmesi sa overí kvapnutím na vnútornú stranu zápästia a pripravená dávka sa ihneď podáva.'
  ,warning = 'Pripravenú stravu spotrebovať do 2 hodín. Nespotrebovanú stravu vždy zlikvidovať. Nepoužívať opakovane prevarenú vodu. Skladovať na suchom a chladnom mieste. Výživový a nutričný profil sa nachádza na vonkajšom obale. Obsah balenia sa má spotrebovať do 1 mesiaca po otvorení.
Prípravok má byť iba súčasťou zmiešanej stravy dieťaťa a nemá sa používať ako náhrada meterského mlieka počas prvých šiestich mesiacov života. Rozhodnutie o začatí podávania príkrmov, by malo byť prijímané iba na základe rady nezávislých osôb kvalifikovaných v lekárstve, výžive alebo farmácii alebo iných odborníkov zodpovedných za starostlivosť o matku a dieťa a to v závislosti na individuálnom raste a vývovjových potrebách konkrétneho dojčaťa.'
,active_substances = ''
,producer = 'Nutricia a.s. (CZE)'
where [name] like '%nutrilon%'  
/*
  update medicine set 
  [description] = ''
  ,usage = ''
  ,dosage = ''
  ,warning = ''
,active_substances = ''
,producer = ''
where [name] like '%zodac%' or [name] like '%zyrtec%' 
*/

select * from medicine where name like '%nutrilon%' order by name 

select name from medicine where [description] = '' order by name 
  declare @prefix varchar(300)
  set @prefix = (select left(horizontal_banner_path, len(horizontal_banner_path) - charindex('\', reverse(horizontal_banner_path) + '\')) from marketing where id = 2)
  update medicine set photo_path = concat(@prefix, '\', 'paralen_100.jpg') where id = 28321       
   update medicine set photo_path = concat(@prefix, '\', 'paralen_125x20.jpg') where id = 28322              
    update medicine set photo_path = concat(@prefix, '\', 'paralen_500x12.jpg') where id = 160461             
	 update medicine set photo_path = concat(@prefix, '\', 'paralen_500x24.jpg') where id = 163685             
	  update medicine set photo_path = concat(@prefix, '\', 'paralen_sup_500x5.jpg') where id = 28323              
	   update medicine set photo_path = concat(@prefix, '\', 'paralen_extra_24.jpg') where id = 148891             
	    update medicine set photo_path = concat(@prefix, '\', 'paralen_grip_24.jpg') where id = 105160                   
		 update medicine set photo_path = concat(@prefix, '\', 'paralen_grip_tbl_12.jpg') where id = 105158             
		  update medicine set photo_path = concat(@prefix, '\', 'paralen_grip_citrón_12.jpg') where id = 187891                   
		   update medicine set photo_path = concat(@prefix, '\', 'paralen_grip_citron.jpg') where id = 122734             
		   		   update medicine set photo_path = concat(@prefix, '\', 'paralen_grip_kvety.jpg') where id = 180556           
				   		   update medicine set photo_path = concat(@prefix, '\', 'paralen_grip_pomaranc.jpg') where id = 180557                       
						   		   update medicine set photo_path = concat(@prefix, '\', 'paralen_grip.jpg') where id = 167749           
		   update medicine set photo_path = concat(@prefix, '\', 'paralen_grip_tbl_24.jpg') where id = 167750           
		   		   update medicine set photo_path = concat(@prefix, '\', 'paralen_sus.jpg') where id = 69843            

update medicine set photo_path = concat(@prefix, '\', 'nutrilon1x350.jpg') where id = 133815
update medicine set photo_path = concat(@prefix, '\', 'nutrilon1x800.jpg') where id = 169874        
update medicine set photo_path = concat(@prefix, '\', 'nutrilon_alergy.jpg') where id =   134088      
update medicine set photo_path = concat(@prefix, '\', 'nutrilon2x800AR.jpg') where id =   96170             
update medicine set photo_path = concat(@prefix, '\', 'nutrilon_colics.jpg') where id =   163140      
update medicine set photo_path = concat(@prefix, '\', 'n_ha.jpg') where id =  151916      
update medicine set photo_path = concat(@prefix, '\', 'n_ha_pro.jpg') where id =  189592      
update medicine set photo_path = concat(@prefix, '\', 'n_1_lf.jpg') where id = 96164        
update medicine set photo_path = concat(@prefix, '\', 'n_nn.jpg') where id =  185190      
update medicine set photo_path = concat(@prefix, '\', 'n_nut.jpg') where id =  163558            
update medicine set photo_path = concat(@prefix, '\', 'n_oc.jpg') where id =  151917            
update medicine set photo_path = concat(@prefix, '\', 'nutrilon1pro.jpg') where id =  173945      
update medicine set photo_path = concat(@prefix, '\', 'nutrilon1x400.jpg') where id =  171639      
update medicine set photo_path = concat(@prefix, '\', 'nutrilon2x800.jpg') where id =  182096      
update medicine set photo_path = concat(@prefix, '\', 'nutrilon2x800AR.jpg') where id =  191008      
update medicine set photo_path = concat(@prefix, '\', 'nutrilon4x800proVanilla.jpg') where id =    160735      
  
update medicine set photo_path = concat(@prefix, '\', 'nutrilon3x800.jpg') where id =  166730      
update medicine set photo_path = concat(@prefix, '\', 'nutrilon3x800pro.jpg') where id =  173947       
update medicine set photo_path = concat(@prefix, '\', 'nutrilon5x800.jpg') where id =    169892      

delete from medicine where id in (151922,172343,191006,132307    ,169889   ,172344               )                  
delete from medicine where name like '%nutrilon%' and photo_path = '3.jpg'

update medicine set photo_path = concat(@prefix, '\', 'hipp1.jpg') where id =    177165          
update medicine set photo_path = concat(@prefix, '\', 'hipp2.jpg') where id =    176184          
update medicine set photo_path = concat(@prefix, '\', 'hipp3.jpg') where id =    187981          
update medicine set photo_path = concat(@prefix, '\', 'hipp4.jpg') where id =    188326      

update medicine set photo_path = concat(@prefix, '\', 'd_c.jpg') where id =     118212           
update medicine set photo_path = concat(@prefix, '\', 'd_g.jpg') where id = 125842      
update medicine set photo_path = concat(@prefix, '\', 'd_c12.jpg') where id = 132156      
update medicine set photo_path = concat(@prefix, '\', 'd_ft12.jpg') where id = 159928      
update medicine set photo_path = concat(@prefix, '\', 'd_og.jpg') where id = 183694      
update medicine set photo_path = concat(@prefix, '\', 'd_rf3.jpg') where id = 173034      
update medicine set photo_path = concat(@prefix, '\', 'd_pf.jpg') where id = 179104      
update medicine set photo_path = concat(@prefix, '\', 'd_rf16.jpg') where id = 173033      
update medicine set photo_path = concat(@prefix, '\', 'd_es.jpg') where id = 179101      
update medicine set photo_path = concat(@prefix, '\', 'd_mp.jpg') where id = 179102      
update medicine set photo_path = concat(@prefix, '\', 'd_ft18.jpg') where id = 185419      

update medicine set photo_path = concat(@prefix, '\', 'v_novaderm.jpg') where id = 188601 
update medicine set photo_path = concat(@prefix, '\', 'fixonel.jpg'),originalPrice = 12.39, discount_name = '-10 € '  where id =    3 
update medicine set photo_path = concat(@prefix, '\', 'af.jpg') where id =       20
update medicine set photo_path = concat(@prefix, '\', 'mvh.jpg') where id =       15
update medicine set photo_path = concat(@prefix, '\', 'skje.jpg') where id =       173984      
update medicine set photo_path = concat(@prefix, '\', 'mur.jpg'), name = 'Ústne rúško' where id =       151798   
       
update medicine set photo_path = concat(@prefix, '\', 'bb.jpg') where id =       192173    
update medicine set photo_path = concat(@prefix, '\', 'ig.jpg') where id =       152832    
update medicine set photo_path = concat(@prefix, '\', 'ck.jpg'),price = 5.99, originalPrice = 6.99, discount_name = '-1 € ' where id =       169673 
update medicine set photo_path = concat(@prefix, '\', 'cap.jpg') where id =    178674   
update medicine set photo_path = concat(@prefix, '\', 'cp.jpg') where id = 121218      
update medicine set photo_path = concat(@prefix, '\', 'ind.jpg') where id = 178655      
update medicine set photo_path = concat(@prefix, '\', 'ja.jpg') where id = 162088      
update medicine set photo_path = concat(@prefix, '\', 'hed.jpg') where id =    45606       
update medicine set photo_path = concat(@prefix, '\', 's.jpg') where id = 14890       
update medicine set photo_path = concat(@prefix, '\', 'bs.jpg') where id = 112763      
update medicine set photo_path = concat(@prefix, '\', 'ccm.jpg') where id =140851       

	insert into medicine_category values (177165,13)
	insert into medicine_category values (176184,13)
	insert into medicine_category values (187981,13)	
	insert into medicine_category values (188326,13)

	update medicine set photo_path = REPLACE(photo_path, 'marketing', 'photos')

	delete from medicine where id = 122732      
			
  update medicine set available_quantity = 10, available_quantity_as_string = 'na sklade' where id in (178674     ,169673      ,121218      ,45606       ,152832      ,178655      )

			update marketing set [description] = 'K nákupu ľubovoľného 6-kusového balenia Nutrilonu 800g získate vodeodolný podbradník Skip Hop zadarmo.
Ponuka platí do vyčerpania zásob.' where id = 4


			update pharmaco_db_access set value = 'select  top 20 [id]  as  [id] 
      ,[name] as [name]
      ,[price] as [price]
      ,[available_quantity] as [available_quantity]
      ,[available_quantity_as_string] as [available_quantity_as_string]
      ,[description] as [description]
      ,[form]as [form]
      ,[usage] as [usage]
      ,[dosage] as [dosage]
      ,[warning] as [warning]
      ,[producer] as [producer]
      ,[prescription_only] as [prescription_only]
      ,[flyer] as [flyer]
      ,[active_substances] as [active_substances]
      ,[photo_path] as [photo_path]
      ,[discount_name] as [discount_name]
      ,[originalPrice] as [original_price]
	  FROM [pharmaco].[dbo].[medicine] where id in ( 20,188601      ,151798,122734 , 180556    ,187891  ,     152832      ,169673  ,178674,121218      ,178655      ,162088      ,  45606  ,112763,14890,140851      
)
  order by  coalesce([originalPrice], price) - price desc, available_quantity desc, [name]
'
where name = 'select_medicine_for_main_page_sql'