using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace L1044_Longest_Duplicate_SubstringCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            string ret = s.LongestDupSubstring3("nnpxouomcofdjuujloanjimymadkuepightrfodmauhrsy");
            ret = s.LongestDupSubstring3("aa");
            ret = s.LongestDupSubstring3("banana");
            ret = s.LongestDupSubstring3("aaaa");
            ret = s.LongestDupSubstring3("abcd");
            string test = "moplvidmaagmsiyyrkchbyhivlqwqsjcgtumqscmxrxrvwsnjjvygrelcbjgbpounhuyealllginkitfaiviraqcycjmskrozcdqylbuejrgfnquercvghppljmojfvylcxakyjxnampmakyjbqgwbyokaybcuklkaqzawageypfqhhasetugatdaxpvtevrigynxbqodiyioapgxqkndujeranxgebnpgsukybyowbxhgpkwjfdywfkpufcxzzqiuglkakibbkobonunnzwbjktykebfcbobxdflnyzngheatpcvnhdwkkhnlwnjdnrmjaevqopvinnzgacjkbhvsdsvuuwwhwesgtdzuctshytyfugdqswvxisyxcxoihfgzxnidnfadphwumtgdfmhjkaryjxvfquucltmuoosamjwqqzeleaiplwcbbxjxxvgsnonoivbnmiwbnijkzgoenohqncjqnckxbhpvreasdyvffrolobxzrmrbvwkpdbfvbwwyibydhndmpvqyfmqjwosclwxhgxmwjiksjvsnwupraojuatksjfqkvvfroqxsraskbdbgtppjrnzpfzabmcczlwynwomebvrihxugvjmtrkzdwuafozjcfqacenabmmxzcueyqwvbtslhjeiopgbrbvfbnpmvlnyexopoahgmwplwxnxqzhucdieyvbgtkfmdeocamzenecqlbhqmdfrvpsqyxvkkyfrbyolzvcpcbkdprttijkzcrgciidavsmrczbollxbkytqjwbiupvsorvkorfriajdtsowenhpmdtvamkoqacwwlkqfdzorjtepwlemunyrghwlvjgaxbzawmikfhtaniwviqiaeinbsqidetfsdbgsydkxgwoqyztaqmyeefaihmgrbxzyheoegawthcsyyrpyvnhysynoaikwtvmwathsomddhltxpeuxettpbeftmmyrqclnzwljlpxazrzzdosemwmthcvgwtxtinffopqxbufjwsvhqamxpydcnpekqhsovvqugqhbgweaiheeicmkdtxltkalexbeftuxvwnxmqqjeyourvbdfikqnzdipmmmiltjapovlhkpunxljeutwhenrxyfeufmzipqvergdkwptkilwzdxlydxbjoxjzxwcfmznfqgoaemrrxuwpfkftwejubxkgjlizljoynvidqwxnvhngqakmmehtvykbjwrrrjvwnrteeoxmtygiiygynedvfzwkvmffghuduspyyrnftyvsvjstfohwwyxhmlfmwguxxzgwdzwlnnltpjvnzswhmbzgdwzhvbgkiddhirgljbflgvyksxgnsvztcywpvutqryzdeerlildbzmtsgnebvsjetdnfgikrbsktbrdamfccvcptfaaklmcaqmglneebpdxkvcwwpndrjqnpqgbgihsfeotgggkdbvcdwfjanvafvxsvvhzyncwlmqqsmledzfnxxfyvcmhtjreykqlrfiqlsqzraqgtmocijejneeezqxbtomkwugapwesrinfiaxwxradnuvbyssqkznwwpsbgatlsxfhpcidfgzrc";
            test = "sekrjeqtwbsuuxgdbfeicerzbwlfbtrgjlzniyifcnyscowbuadcdunhpubibgdnjkrhjfuiszdlxjxyzykfefyuvfzaoycfqwgoalehuajxitdquayyadvpzhltzwysmnoivogfzrwjnkeuneplmijtiocjtikvmkfmdmazmxgvfibmpoabkaydmiqehbvmurshykclvcwiwxvncckdzaifaomlqcovqcopmvplrgclqtfkozswhblyvovuquhxbhcvowmyjtqyvhujacxypkjobsfgfqvhwelggsavilyyxovtzslgywcpkmrkezzlycjedzlxjjwwepmtnfgdytqbngsyxnzaedfhmffzhzcotquqwegxsbpfskigvpaeblasuduybweixwyvlrkhyfclevgnzgtomdntdzxcjkmrfujikshfzpwubftxphktptommaaewxeenhbacuitohxmlwsvbjcfalegqecgxpafnvrunvexnvusfycroysljoibvgqonasonbuwlhyhjgqyqpsaanadpkciwadqovcugzehknxdnnqeyidhrnvkpukurvfvfmzzpihejbjqpadyxagjcrmigggwhsfsuecbbdofxaiviyqghovwtteiaeihbjhflwtgckzxtroeorzlqkyejachhtcirqkahzlcqhkyarmjostnpffuwlolznrenkeeropaqqspyrsdrnnvxyrlgklpbavzgotdvnyoekmuugreujcalynoplxiicqmhlwrnjalcdoyvizlylkzfzmlmomgaokqvdrblelqoywgmyzrwhxijpagaqjtehwolovaencleeznqxccuwvxjpqtgacmrlkmybdwofgkzyjtcjwjhslufosebfudawqnmefdbzdfdgydhxmgijrjwlnkieuvqblwpcgspmnysalgpwiekszjtqonaqkcieoqtjzkqszcxxdrlnkzmadweebxnyhmiyttufbbesduwwedhjkxhtylfcsilydhwhzbcxzxhrhvkbzacxwsyqbxpmriwofkczvoexpkiulqlnnyrwybygscywyawfathuqmlnefwqnibiberalcaeeqnwzcuwvxtusjvpjkuxusacztvpzdtcgvjhdcwuihdwbiyzvbmozftchrlqwsuyvvlhdmwraodifpeithewgvzltkfpjsgysxpwucfcdpkiysbatgzyhrlavjqxvgaypeqowdyoqwqqdtnonxgelwiesezdglmibwlkyxgxzxzoopnsgxwwkbzfyxomcxsaasxgkcjwxxpdlharnnyjuhxpdleyzvpuefhinruqbraqerbobkfukfeqbojydjxayhpmaearldlscyeqswuvjtjatrhhkcridzybeytyodvuyycgyqqpwtmpzgftoeshvodgugsbvilgvllxbgpthdsvkunzbeexfbhvkxgztmjfrshtvhsmgczqzbvencnaakdejldupswmxncpngetaofvgoscyvknyrydwacmvsgweuaylvkqmcuatfnrjgftsjbituyzbxarqsbwcpgoknqxdqcjckamagtjdtfokrlxegobmhfniltxctahwvsynteabrdcorneabwyedjbikvhjjauexdvtwtdwlxpocpksbgbpykskrrbjlektlruzlyanhecyypunqrvzztfkbqwmncytwfgsjhkqfznpacuieenydtzskvykmlhokhrufivlbiktftuyktduwackphjcllceshamgepfrgtmmhmzoyhtqtenjqiedrvhylpekgfpgllxqrnaqaiuoftatxpzgnetscaykbkccvcjjqsnrsksipobeqfaklpmvltohdpmnobqjbkazoufsvqkljhgiqwmaiacqcbqijnqvueqtffgxadupxcbttnztxhurxjvzveioswjzfcoaqsxhwexjmzrsmzsydarhkgekkgohzekqmdzpfqtdfzazmouxyqyfmrpzexigwxfdnpompqhtxjylwqtlnishysjcdqqjdrncvgzcsbogirohqhgaqxmwmjrpkqelvyiwkgohqgthvpikdpylrfldjsfgkogjxzxylrwpqudnjlexrmteujaejoxwyxcdkwsljsqxgmkgtwzroyrtfrrwnvzoipzvzityxwtxgjrhlywfmhwmxcuimhzeeqylanzqkwgjeemjdezczcfiwpmdgygnsajnfjkqgmospwarqfoexbsjjyvexqrudsivvjkdsvjdfdppakvvlusfrrqajwaxxdmjvihnfdhmjtoursffsmhnukuloqvfpfacpsxroixuyhgoutpkynkeocesasujjbumyndkyewzhsxblqhoteunszhrbjiiqvlofhfpatzdxvedostfwuyalwxxyofegsezlvlgecwfchtccjljdrmkbkiswrjjncqxnurgmgwycscijhtldpntmqdnwhxtaizniguweartbpwxykyynkfqllolykgotkgrweydhiskzuoukrpttvwhdloylhdhupjfmoxjaoqcinzqlkcikghshmpunctogoyatsctcboqwztmajnnlerrphnlfwbwhlpqvruxoeoqyruqvcyysapaglqmgycoipwihjamcgihpfifkrqpjfcsorrzsrdadioakkbypgdqcalkzhgvadfmtyihnidblveedlinqxisyucfmvbmbdeyrhvatqbwrcpktjskzamkqyttksuteilmdwyhoeuzopwvceyexmcashuzqyypeelevimmbqihyshfesbmlvksjpqyyaxlfoqeozyabxeefxwelxerxtbpykwgsfsiteevsseazylkucmawvikojqryyvgwqvleolcidwjdrwhshjpowgiqjxwwulrfnezdzioyjtahoswdojsejowxknlqpzynusjespbcdfbldaputlzbhmblheabbcyruogtpshodcukonwqicbpaiigxkixhqjsvsqfhhvjibppzciwfclwqopgdmkhjbpbqlfunzolgrqlmcotohrvgriamkhmqxhywxjjudrgehtehvhehhsmjwcpdlyqawaxvflqcxlhmyfuxqvvxgkqokbzyvmhljmxgkoferhfunhmsdpvtfvedsppugrkdjftsexmlvbdstydwpvobsoedyavzxdovrocrixnruwagezcztopqwvkofjvasghisiiddlivmodyykqhgfcokfqjokjwbzbqbhxklfzdorshpplzednpbzjghhqotsrpbvqxrxczvxgqniuskinnzxysfmwbrzklcaaqdxxshlhyndiwebzqzevlxwqipninfcusbuexycyvatueahvstbxnbarezmtvrvgcyovjnszkjkulbaeudghhrltvmzzzgcozprlsekkfxqjcddptpekkorvvfewyqdcvgzrujjoxgaokwhywkvegzweyldiegqrbvvqfamwumoenitnqqvvzbnnxebmhknjvzujffegvyapnckowzjkfldohjxyemyyyzhzdqhbelgdqnyjdrxcdvwrounvjqnoqjumfcekhkvqgtjplkmkmawmzaushphffoqvtobcfqqxxevnbueznhoblvcsvdglqcrevjeakcqazjfvudawubsalgbxwrnahdogbqilfldfudzyfazfdxscqwzfuavllzmdgwagyrqtfqdnwrucrcciizaqxhtxiavsvsxmgwiblzqqcdtwuonuriodeaxvnrtvoplyyvguzlshlqggrgzzjrljnmdfvepprlshojmsbvjkssrjmwfuwgeuqzwknnxlktqtaigavpppryutefbbepcbpxtpewnebjkhkcesgmgcywqvdmahhwexeqmuthdgzzlbuidqzxusziwaojjqbxjgivqorpbijxtbrzzxicqfrawykvxxzkxswlvptrlqedxglnsabwiymvjnjkpzhgbghdyvqklovyjykkejinxjdndoryfpseeuvvvlbumwtqikymjgydxbwcdfbhdecsmybzzefdzobypgjmiktdmnrodhocogkqjezmksmhfklorsviauawldjuqkgpdyhomuwebeuhpjtofhwhwzjnhjhpdnpsvyymbdppitmmmqsmizpzeklwbdzwmfkiwvtojbnqmtdlifynjebhwikzbqtaqpojyuhtjbjbetsfpuykleorgwdvvoohafjvrffsqksgwnmnrcaoaryftazhmuajwzlniqvnfhazkuhomllezqskbvdomsmnadvtwhogwwxplhkqwzdsusuhgraxemblcnaqqbvyrhkwpnufnhjagweuweycsniypeebhwcxeqlkeabbfjdsocybvgelygilleyhjhvswyamsygpqawwygxzvlucocsdwhsrprhoqaeberolyrgrppjmsqybhibgdvbuwvcvoammarajrjvdwofnmmfcrxfuuhlwvenhjufqhjmniutkweunkqiybzgpvgasfhizlvmfovcqbsibqhoklsaheezxmqnxijrqdsrsxvyuiolikntavsothnaafnilcffihvgoftfgkznrtfgvsavxpvqjarozyjavxhqhphlsnnsgjxlkaqgpxqndqegnvjcdkhpetqidqgkewoaxfvrlhqdgzottngzybjerfduoybyczwwppeauriixzqtaidnxmbuncjbrtjytluweuovkqmlfapqzllgzwtbejexjgimasmcdvxyrqfjnhbbpwnhgyvoonmnjjrztxbqmieozexevtyajclvaplhdiuydjbpqrgynzqahvcjarmwyrzsyllkjznrqkgkgrilbyjaiglwsxfvzkmovnongdcoqzchlyfhrtlwrvcevmgsucsofybueutqceixrgexapijkcqtezivunshzonhcuqazrcygbmswkqhtjlfdjdheraiolbfbhzmnrhvpxhzogjjcrvjilqwmsugyayjyjdzcnhfutyylwbulzycsewzngufirjbwpmerbgokyefbhcctpwdndmtvikqzydoxidyqnfdlffowssefxjpolmdjpvgazvkpestilakuqghfebfaepzpqrnzpafekjzmvngonmrwtqfnrmieytgjsmocdgexdzqegvusoazzoqkbzwdmeiexebqatszlmamsrkashnjthddhwjixfvljfqgufoxcveqayzeosuxwmoicnopebknyvdiwtowzhxafqvkckesuzxuiqsqwtlzznwigljpmpawtkjkqodobvatxqqdwhjpmdtgthtczqnrqetwmfdrzahramnosvqzbauouhxdmdchkjsxgcquoupwroiblzdoyimreenkdtdrbdtqgohcojpynokjfhqnhubecvdztpapthqufhaydmhommihdceiadmfzmbdkhpmaodgartpdpcqvjtrjupqognnpypkgtohuxwclapmccdpggluflwkrjwwmowugnxryfeovjrmorwwqxzgdrlbswvmviqqgwdwtczozofdsdaysrxkokogondyhcyjygxadspxgcolgoqvqncbperinsfiyfxxqqnawdpbakqilddcpquqvbcbtsoenplzvzibclkqgjykeqbuvldoabxdycvihpwvxbdequzkhelzpsidwwzqokpbbmaasvcbqirqgryatjwncgnrebsjbccgfbnzvhjdczhwgviqgjdfyfahwwocnkgkwvkhfhlemncltmxjijzflkavmqxadbbnkqsjlbrypwpahklbzplzitinayoqyuhdwmavfexgkvmxcbrgpbczrqzpaerrygpxjpodmlxbnqczbwchbggbuxmpazapikvcczoinoyjeofonvhfpfjpkdqwwinrwimjqfikwohlphlodunlcbetroveapxkcpbrymuwbcxkpsmpxtlqvmfhaxporhiaaezvzkcdowddupdweveeciuzcigembqamwqgkghicsrpnzxsdyjvqwovbfvlxdtkxmmochgwifjcnabwkzbkzdndjoeqbxooedhpuwyhywogvlazlkjycaqqdpoinzwixzpudunktzzjacxlgyzlnmedxnzerpvnnakwzbibqybijjbxjinpftqtnsaamuuqzctdpukkzifukgefibfscvirngpaazfswmcmvldbzdwdbfzjtvfwmgpqldrxpjpfdutrhpwxpfdiittxjxxkqadnreczqumrerzdwlgavpbpchmlashkmkafiyldonyazhmzexaeosefmrzxupwateptmupiyulxqxjeyxjslfmheyjvsgajcjuazcjhzlbfijgidekhmercvhczxfzhomedtgshlabqxnexfiosqmufpslbqsefetjzvjjyaprdtthvdxsbxelurqdrkigwulytgzfegqedoyfwgnwwtdifbsfmpnlyyaviiojblnbrwvbzpeebzxdortgqtaalpqwgkjwsaujcfuudxcsjdwzyznwjceyvjsatqdfezhwuyncvjghhkcvabtfvdbkfakskjqrpfqmesurgcuxjlcococuayecjhakxgrsvciwlvzaobrjfdklwpawtbjpiuecgrtblaofomhgfrtjagrsvnusktgjeldnlcldgpnragamxlmdemghbpfmxqsahpkctmgpmwzargzedvxslmshcbgyagijiouypiahmykklqgcorffmepqpxagytvwpfrgbcgxncuxmxshlzgcovbhifdchsxwttgtozvsavckrteuyjtvxqdmegxxoqrepybmhxcqdukkdhumcbwyshlyxjplpdwypyjnhdlajyxxrysnjlihmbzijalhdbzowvoiwxzfwzeehmebiwdjluunjnigndhdrsnjeistrwkvakkwwqddtsobzhdzzqbewmynhqbnmjinmhzospufoqdeywairmfqfsazermfppfrcxtdldilvvtunjcjlbnesnfmhkzdxdhhtrvuiptjfmznfgckmqrtczfkyrgtmfjsanumtkjtuuvhcyxtzlnvjnwlowlorvzhdklpzhjtoawqdycemdjesefjmdsusdpsrqyvvzmmzanhmnvkcplfyrisewwyltzdowvaeojstkwgpamvtgfarvhlctwqvzaxzxztborzpirscqxpprtzgtysgpetstmfosgsohdmzlrtmregkifxajimfwedonvdtgnpvrplkomosezctfrxarwtnjmhavzftaqbhcswqvxxpcycjrmhtvkyyeinyhgeunbnyerrjbhdjovzhoepbzazehyntvbmmbtlgnqjtosppkoedgkktbprzumskberfvkpzsqzahsaadwoqxuktuvnbjgjrnsiettywkadvjrkoxehyhmtutdzyopxwuotwgfzcaeytugnquxngtfrrpqfcmskghjjcyzlyllzfrnldunowosdedrqlzmqphlzaskhfmpfqmhsjyifvqbbfujcmrxwgxsgdcjzqitslffvnsvxlpppjbbqmkppattqsvjtdaemjoflcztehmgzhsdhhsgqltvoxqlienobosgrkqxhkaeqiudlugnhksidtjukxiuovumqjfcjibjqjhuamyrandludacqfnsdhbkfdtgkskuatbvnonnhpzypvtrcbnlukjxzsvwrjilexrlqeevktbaebefauifsckyfaikqxhwfqrdnryozaiivlxdnsmmiooqsdkrxuapzfvvnwalgaysojpehjccyknrhbqlrqwqxgpfplakotwxgxxkzywkbodducqjnikobdkvxorjvtfaoegtbzalwpybqqypkohwqvyxqhkkssqwynyeuxmrkvxphbxnayklpvljbquhsnxpuxcokhugmyzwqzkynpzijccflouapczqcesxksfzpixiduzjhnorxnjbkkgwhbdrmkkcjcaztzjekopwahjomwveeoolnbgjjwsouigqvyuqcnjgcwskiotalleojbaspymjckhethonhtiqxnvvvunlmfykxopsoozzccqawtfotufspflavimnvngyetqrajfsjacmnhncelmyhaakcbtwlrrbeefyiyckndhxbqvslgmyyhooazliaxbrvjbtjsfhqbpkyvuvxdpoxrwczayzldnrpadqpimmzeknzpgiznebygyfgaqszhbfwdaxlisycmfjwdiubdhyjpophqaweodxazzmsttoykaxiuggbfrwveprisbchdtfeqdrqxmkfpztuyirvsmjxyjlgjxrmuucfsurfiypjhhpkwxomnxyutprrlpsftzoukcfmtapyjhwxbpczzeqesyianqzhptbmmasyhejjcsoyuavvhsxeobejvqndvgvbztobwmqolebmcykagpadeklputgomgyfoiahyntzpgxqzmguglmkxqokvxzsdmvuaxhlfxbkfcpvoymhrgxoulqavrjwlgtekbubulgmpeuqzbbwqzbdlwbfsgojxaktojnncqkomhqwdkhizxsezsuxtsunnedfhtwcnjjzmkxayckayfchrasozjxkkaqthysihthavhdgixgekqvdqofcwwvdbphrpdyeuhtfzxbuqoaolrxebvbjguebkghrmjfwtyvziizokesprvetusoiybgumklsnmcerbphormxfylocfqhiruolgmongabbikdglbvbrsygbkqsggjjunilmsfjpfuoapdiawxgddxyxkkzrkjofulwmavqqzwixibbzzhzasksxtzsdoizxnmortkfeedguejzxwanbdhyihqdzcfoahziojozxpnvcdfdrkyyfajsyholmygpffeikvmcfactsgbeglcpvefvzjidnsatzxrfqcpmctahwoexsbhgyibotlskwyiwsgfnapzhimeodnebmcioargajuutlpuililctnemlodipbtckisovmvutuwduyumozdvlmuqcetbavxpjdcsqpetugpmmkopjtienmdifeptpaermtbabzzsuckocfyiaifmkmpqhtgoznqpklokyibnkolcygiclgkwuczwfspylflwhlgrvdsyrwjeaoqhtnppsadtzphfdjomvepflybxaathuhtpoupejiwquuxzozjhntapnojjxphlaxtpsvdffbboozscaxsowiwqrtqbgcgexmwfbtlvqwexemxjxgidgzghkgrnzqmnjzjnpklucneliavsinhcsicydutxkcjvgibdhaemqbhxescvwfeciqvqvzjplnczhdghaxtakxzvmytawpuqiqdryhifgjzncwycaamhkcgwfvmbznmxgkeacsfyuyusalpzbsojzagxcusdtdnlplfihloxzhatvterxzjybkrunwvmoxjnhkjkmxhvkwnrlyghjbpekuquddiyqgbbngbzizgjrzlrzxnxkoiyxzubhqwmfikrilqxhjcciecmlthzvlcrwofwdwnbuskhkanbfpdrcwisavqpoxwwqzckxtwigyoonmazggqsclsctjhkztjkfgoirtjwchyuzsazfsjcbxjfzkcdzcumsuizllsebllxsjxfykwdhdqemonycyvfhokegiepzgdxpvejqonzqibdvmwgcsqemuqntmjpdvngxqkxcfnikfakevqotkltfbwahlmgqedldhfusjnuwuickwfnehfkajvwwpgmdwjpzfuuagyiqkpilmnmiylngjhtnlvmkeeuhvrcxrbbpupgmrzwwsmzvsfyfkidlshkcgmpnfvegztmtaoecupdidejrfoqefqsmloowksssqwxervzbqgvyoemdfvepqqnfsmzmepelqtmnjpimkxvhcatwbrlodcudgerewwsnbscsxdcrpzryafaebkjkwkxqeuudbzuroiruaiuokodnuvwzdxhswcfwrbwbzkyzkselxejvapovohgdzrqsrhgibnogfjflzgompwbhmwfoofqflrfajazmvkntvapxehaajvvuilelrqttjtedliykkvywccqeljhravblxkoksisltzfujtljpbtfmttduhhrjjanqwduvtafxvrwvasgwcpqqlrjoatnrkqozqirgoxzfywnglykwodjvdsymcusumjkyrbgufgismhaqhmrfzxebpimiibiezzecgtxrfbtxdenffitdtxcdxdxkxcskihcpfykwpjaxllepgqlgukmkzbhhqlrvrpjzlkztwzkygibfthstnflpejrcpzpbgomlslrbplqrwrajsnxoerqoxsrqpxgklrgrbvdcsxxthiybqucyremspgdwmyfdxugizfmnbowxmjniqxwcwxrjlabvorfvfiqbwtslyanfepbuzmyufhkstzfpuisnoeodfaayvutxbhavfpbpdosamtwtwxqeirulxmlawjgamyseqnhenogukocbpebxkmwgbjopojmhvrproyyzmmtrhrphhcswhdyvjliiliyhpgdojbbajfqdmazeitfdkpsymjwcswcblfqtvqdqpozsdjzoqmsmoacwruzczcplbtkzqphgsjztnvpqqhsoypkhciwhgmxnddumvugzrkhxpcnncikufvvlufelycinwgeigcpdkbvmzvfuurwnlzcsioewyikyfivbotheismedwpascogwderstezsdkhxecmholunweqtfoblbykjtxezavylfzmnbfzgdtojzmsojrgwprrppijtfhrwipptdtntwnacgpuvytibulxjoccwoycjbojeujylccmzzuhkencwzurbmauxayxcuobjuedrjwmnmatvmnyqntctmkruqnlzjbptfdayrwsvpaiztdkkuxhgwmklxhdlxordodgwysdktoxyefnuhivspiaqxjlsszespivbjjnshwmdjyuaqygbrzfjmqyusgmetzyjyzvhjojeutmwiwzwyjeyszxerjvjgsmsbesejukekwqerwxevnjtomkdtriltquwvsccadqucdhykklgaaztzxmbxofmpwwxoamurfaspdfpkhaebikiqqzosrccncmgirkorboudirikmkkrahxebipsevrpcefrwkokuddglcdjqdcfmovanzavvrgjditzhysibubcteaetqqupoudyfhqpkobtnftekborklcspgpsyiisazerubxtkooejszfcommlystlswwcsgqnwnletxbnpouciavjsnzqxgabarpyyhzpubgsentmpjjjepcmjjmmtaocqanyfphwvdpbmwichphmamnlttzftmkabcmffuxflcgkmxpxhfwlhssppqqtnqnijqmpgkgfqnasibxdszzkinnmhaldgqoouxipjgwznuzcqrowlpffavqqacxsadayuzjcksgqdiamluohtmvgzrxfxebvizyzbnbehhamjgtfskczfyygjcickptgvrntulzoptjobfudtezlnnrtmkzwhdmxvtumponqntozxzkfeyyifnautlqfanovttxgeglnmxnxioglfgtefhfhewddnzlsxvzjazglnxxoqbwsqhngmmseoxsggzndfpgrrlfgdmotxvtremgrkzlammtllevfjeheupflurdlarowvdbxktifqnwrimpcrrbnhpevjbwlimqwqbkcflcnaswzcevkzuaginvbmvhczuifntfwzhswuyuiuazmrhpqejvhhzpezipxsvcqxbnykhtjkzjekuucbuwfigpdfsqyglsayeguznfqkvguovwwamjkvgxxsyrcxtztrcwzeizzemjlqsvrmpezgivqkkmxbobpockcukryggoovzrdllkypyyxnpeifjublktjowscnwbdhgigsuphfyywgefcmuexyjofdhozklvpwuikwmivtrlqvsunptldavjcouubrjssmvzntlsaawazsvpagicrixsgdgvlootvhnjajklapwnxwtxjxbnbwmpzlnclbwjuhdjdfovqhlgdwbowqlyqybszxlhhcmmekqsjienwkfjzutxoicrbhzziiqfmmyalbovcwwqtjuzzikfeleuhighprtpbdgdjmruvjldgzviicwthrmulxttzlywgtbzsrhlldceholysruafmrevsfgdnrrnsnbkkphnieuafaewgkcxntwckyfxaofmtqwetcyyavfykfeeukwbknqtwdjdkadaascbzzmmcjkfgilnzedcvegxymksbpddknlsaktjmqfsxyiaiaueljbncuvstwnzrpzyhlzmxocxhakkqxjehrusaqjjbfcojtkmrucsfnggcjsrdibhjfwaydulwfpmpvywajishcpuaeeqjrmopwexhmvznnlnajtyujiwahuorcgtqofpnxbgcprmvuputkmfolmdnhgbovyiuirqfpkealqxdozzbtgrpeevlowqgkaljlpcrfmiqxelljiwwjpcmzhpnmugubkxqveqbcjwscoicbomvvxkolzuuarupfhifkimffqadgmhkdflfxgnbqlaezdpowduzpnvgkvdympgltramzfzkgmeefqrvielnapnahpdxiwgkobtpyknpvxzbdkcwjvrabzgdwljukasnhduhbgerxkohcpqpgfxjfoswjrmhioqmixdcblawwtdnnlcqjpfblquzybqbcuwshqoevfudmfotiftaeyiyxdvqxoizbzkozbvtjdoivfglqmvqzhivqfewdyxffsbivxpviyscznehjocwfuamymjamhjftvuovbxjevnulmlonrfofpylpqcplvewrraxftrtmaoktyhszjgvixhvztdtilueemdskegiypqtygyptgyvlpfrjthpfkxzuyjaqumkseglnqnnzufobhjnecycwybohuhahglazddadxnalwoxedtuqfxvyrfkboalfspytbbkgnzettbayfupnedyjfvovydavyizkgjwcadoihxlgsjctfuaffhbcshecnwzybitplggwzmlezrobleigdvmkzhgdeijqyrlyuqaknajnvtnzvbmoguslvqzhvhvbewgzrynhmbfcdqftswtboptvrywrujtrmwjlsfsiqjybbvjnoibuaycbzsedrehqdnzmmpgqrbfgaicejhlyuryeebsnmlmdclwbutsmazbnriflgrurkrkzthmdpoeshzcexumaawelkkdbuqqycgqzzpiorerpmdlwrbiyprrhusgppoclnabzecficrrexwxcbiwayarzuybvvyspmcfapklsxaitfdksaywcateifnocgcetatpsrpolhckqvbdzmuzwxqzyaicscwsdtgpknqptqhbtmyrjdegkyitesvlkzhkvxjtllrgqegtuabntifamrngohoczpyhtueiuiaxntdvknsynexgkwuoldxpyihyziakhvnidsyvzbgtuuhrirtthzqtxttuamifqlshtunznzvfhxrdlggsabwdjqzlzhbasmqhzcsuxbxrwfdsjtswyreuixnyuheapvfljbdfagkakqgyxvowovthcfxrgsqxqjramdhuodjchojqmyrzosfvligtyvafbdfzywkmszhdstogxvcjjzqzsnrqennzaujyhgwxzhusttfshpjymehxhdxxzynjpfgwtdfgkxrqiiqamkoyxhqelchobzpqnowlaoqswsjaahbaacrujiabzmyhjaewzrxuiaiqwigyqjbhqqfxiupfqejjoiayoadbokaaktdsehqvgeliqpjjugdpcywamxhkapxilkoigucjzsjrczzvvmqyoqgoowlcemtprapiodnckrwnleothpmmptpzzvtddqqfpicsrbdiekmqzunqmgqqeznacczbobxratkwzdiiladwelnvrlueenzufwusnlpfftuabqvcrsrutjkizpreayykaoiwqpyuryutaaiumwrhyzpzwgiwvwyrisycazkzsgbzgodfucvhitsxlmyaywqucagozfouwxlwombbfyfghaqcvkpcrpsvbcqlmtfwfaagmkynygctkhehpvtrrvpehfmfwqfwhkuzjqqeitusqojdyhhgthgujjclpsbtdiybundjbsylhjtzdegnixhafnfpgelgvphhvgjlmczuxyfgirjcvxemgsoothgjyihsybgltwqodtgylndjrblaedyzuewvojthpoaveidhjoxuwvxwvdennuujjdhvweexpxyduuzqonkihymoctylvxnbymgfwsjfkeqavhkjdauntplgigueeyunbfwpicyyjnsilshtvlrcwzfhhljaxamoiiynkvuuqnnmafxtvibngrnpukyyapuxabyuseogkxzlayxmcmguzuxnajrqedofgwehaofbhozrfepnlmsaqyazorclwcexoqkrijyrvtkphfymqongorzvqffnoaruscfgizmtdvgnflgjdphxynpvidbizcmnxbnjppdkygcopdksqhihesvfytbmbbfgdqinsbjjbkrorwxqanbhvaogaojokwahwnniivkbvqqklwgfhmgjaarqladhvkezirwcxmegavwbubguojkgqeegtfhxewsqufhqlzurmhjaxzshwekbvlptjqnhvamuqvnwrezrcarepqbvembhtvjghhnvsflswarbofoiapmryzptkxicdwidoevrjejjewtdmfwpryttpjsxiyftwjwrlnxmgirienlpbpncnaxbpeixswznppoyuoqlmtozyoefbapwxfjprsnmwnvntkccdcldkvucgstpbwdxdbcgimdccpomtcqpnckwxfuciewmmozuzsbfqgyesuctnoyeplnuxooktwhqtdbxyhkjehjzwbxvyqidujkgvwtqqfuonysepvfvluuajzykizfrficgnvuxqbhktbihvmopjegoohushqtrdfghziumzrsfmeucfgnbvfamywqjswqenatqedctjbhdpshfwnjreyjvuwmxiuhjuqspfzcewryuhuycifgopftajlocdwtwwgzwleotwabyczrnfcifijcrunpsoyvhiiizmcpdkitrpgkfyiwqreqyllxwavvsxblyjnmzfykvpbdofrebajyvrwoxheafifhahyrigfazmfwzcxknloxxhqawmyagzuulavrivhyiouupgwyugpmnzpgetrlnqjimpdvjjedbcxbmfeyvkanjhxsyymhykraswhmottwboeaoobjvgqbmzjmirumxlndbfqtzdalyryicnshunqkatryvqgnmntadaxlwliqeuywihsoxzlfqmzjldqyfvgvzktzahhuwkvrauuqnqhtvscqaqleqjxqkdktmzanrthubbewunzbdisearmddgdxlsuexottmombpqzmglnjkcyrjzynaqsmtyzlbqwdoqtlxiadfdmpbdlphvkaxjeeopxzeztgqobifrnfoybqcaggjeluxsoumgdtuyiepmzppjyzlpnslcytjopeujivbmlthpjfitiuncyjqaoorsjjzvdxfjymrrsrefqxjrtxrnqucqhrzcypebemtulagxllmqrnpdaebmwjgeunjhqduksrbnxvkfchmyqnoldzazyzydmdhmiejjzyuzjtdfblpfacnjvnefocqubbdjjtcefkpyrmamcvhnifyjrhamswbkiwgvafqofqlzqtvigqheophliqfmmsgxxpqsioamjsyrmznkyfcpcmgutmzujwstskhuxigjajivzqbyjdngkeoovkufftkvnmecnmluqrebqmghnhbsvfoonqxvjlsgmcuyzhljvjbaheijjrtbfkinxwwpuspeuyxjkrcjgryppsubgxojudslqgdasljzsvtoihnoddbiphbdrqedsrlmbqndpehqpsgabzvkhgwmxffrbiybegyshxuptiwmbbytftjwyhqsiqzspvzqfzlmoztcixaypytabaoehnpxzvhkwkkcxxwhikbadjcadgdhkrvdxsupexixfozsurljrqdkawqruhyyjhujmnwlaazkccfpijqwpdktjayolhpjhoyhssqzfmdqvhazhgnqaqpyjysmntixersnsfaspjnefgaaxopojhrumgnzukmiczsfodkawueymgwhzuhvdjbytnrbyjqjxbvfbbdrhcrflafjstlyjvihouuutwzdfrgsizqdobvviodgjguwrszpvwfrtplgejlcqaooyxdsctomgouklfgbxnvfphkllpzlsdyjteefkttbfaqidphqvbrtculvkeyvoijeerbmgorycxgscypdjxomaqvxzcmeuvrvbhdqoccsqhqfwigcrrpvnhdunpxqnvzsxjpkpuiazwieteqkwttunwhiswyacsjmuvnqymgvkyudjrtdkjehuhrrjcfqrmwaxaykyddgtbeziivuqkmjgwjacmhiblivmfhuxpeprduzajtvukcebaouodconjqefupjguivntjzwzpejqicktdvxqjwhmnlqkdpfbxcfhattkbgkvfoiiuukyrvrqgmkkputzurntbsssjtvztbytbmqtzztfbrjnmfifpyrtlvpftegcjchtfvogokihqxznhmvjefrhurudirftqtgedqaglstxvwjptklfzlpmuktexhflthlhabgsvtgvamjikydtkmccamhdwsvoyyfgwgvyhzdabxuvswpvrtxfeicrqgkpnvhvgrnwtdbefshwwgointjpaaepkulsgzwuojvacjcyrjteuhidejarkmusklsrvnjtkdqsdmotheiswopxhpubnszrqghgmilhrbfghasmahuibpiowxjvbbqjvpsbdwbbykefalxuhxpcngntrtxrxpliwoenlizjblirmieevtbddyhclwrqgejhdykczybhdsxsbdyhdoyunrhcallduohezpatgzbomkgpkzxpbduumbcgvtbrnkuiyysqdsypbakevzylwxahqulgbxofwfxnmjwhumpoffcqdqzolhqbknrcazciltvuxngauxzsiokemtzuihoawkgaidnyuzukrgjgaowzokdogtktoqwdbqcrgsuelzxofakrjtkjacxvejwmjvlsilzizrmwewvaarhvorklwnfzqwcoeuqvqhkdwuduknffddkoaqghipycgthazzmhljdeiylpjjjiesqdjrboaozwemoualziilsfdrghvntxbnfkkbcmaaulfhdlwmsvxqhjiobzrjfshxgxporjfqxbcfltiyimecdtijpoxezhzqiqtmporocfyebftedsyybuosffxtbfdpvrsakxmerqezawcfybhohozuvbulscqpxbdsvggogygsqqmkrtfqnmyhigmuexiomxwykmgjikhdfecilwobsseyaqsqifnziaifnyyyyrzlrixgtfyizyfwqpttbmzsnudiznohilyzbhqxjomtlfclmdgtdxbgsfhdamgasxliziezldnajhhebffmaeiixrdumsvcrvzvuolxxzicaobnrukcnmvgezdahqfyzsszdtwdcjckdexomtknhvgpgafizjvbhlvkiutcwntbkijzwrhlaoaozexrnhdnkzndyihuhtralrxjoqeduhfftvrwjadpeuxchtbbablxoxlmgxuxrgrfzggshaqhtinuofngpudtuucmxrdoakligcrkclollxxbbmbsmatodnywpmrxlccttaemyeeqbsyfohbkhsmawwfptvrwbuovhqqubtffxxboanljtdqrnbtrpuzqqbhmbzwzyiyldgkmtxffngjzhphionaxebvhwphbjiirnylymsjipzyvjixrfqbrnazjzsryismwbdsvzsjliqdpttshasoprtahghzltpvspctiarxmhkedqfmsgqllmiwnupmuqiaexpeuwqhikhohdevgkcxvuxtaatnstttdwzazttanvftwjdiytjpjsxpayzdjmuyhatpymuxizcecohxrxdyhpormndfwnptqshkevoqbadnvdvqgbqmyjjmczjdxqmguvjicweioqbynfbmiehgdoexgkwbngdtonpzmluuayecxceztunrmeyevdxytuptcguahoqcuairzvfcgnxkebbrhtvvcpztnmshszkelqujkdanlqcbxyatrhhcmbupykphlrmvpaepwhcxrnysnixbicdzjkgwitqxoeqsvuyrsxxjvqqnwyrnyhyckgkuookhmanhhppzfdelvbxieolntyxmupezhqmftfyjljdsocepimyxnqrjxaztbyeesiupojmwnlszcnnhuhjuiokwqnysamczfumlsdvuuvtsppbrofepazvxyruimmlxsuxhkwqzzputsflnqljxfldjbdhtzollytvwmyygogegtgudntjfhskrsekdgxernrvxhpvbtsystrjlgnsftbnurfpyqmaxyhjypiqtaitgjkhradngwruvuciacgnxpacdaljvcdhzipxtyhwniuzyefrhuuswdbpzupmjdrgwmftgdshljomdnjhjfexeamjtfsiixdpqrahishrugiobndhnnemecjyerhmmxplfzwmeymeixedayaupwlnjwuvwmqceipuqeefmuqwnublqhpchxicfgrtshpbmhbbyzrriconhsvsirjunckiswiepqbpjfusrcamhffmnidwjhkcgsfhdoarjklqzvufalvpkcqjpbusttdgsfeugzcqifgzfxhriecjywbokolziobaturiiooihtkrmpwuvohabbyjydyizaffikwfhvroblujtlxumbftvymnnnbnrbwzclazwhsmcmhuecqxpfyqyfuussxsqwtkuwscnfisexaekegyhifdalocduhhoauwopovjscgruipsecqkckgtivydtqqaaltceuvqimtnahqylfzfsuzkwwmsbpmseapilhgrbakitjfoqddplfylyofincpojbjiwhttcgyksmdvwcypccpjzqrplmfeczfqtolvfxqdoqwiodmuvfuekjaoqifyryyzuvqzfrdzpnbwjyuphpmcibucixiwncbchcbbcfjrvjfafloprjkaolboqtxhlgnfekggugpsbwlvpeklzaijmqxqsfybokswnbcnnjmkjfkcwdstryhuprswotbyywsnhbqhpquliocermjdtwohawscebypnqgyihnzcqtgcztvlyxnlwlvjqlaydqzqlztmjtraqemaoblhtqyaltzpnnabyoschxndnzxknfgtmqmvymnghkmoznkbhcajimxdhhimmowpgmcloxpatvduyomzkbizndtsejbcvklbmzeixydcbfxhccmspycswyuycqrsvhklghmylmujwkwhigtzsbrebckildfjgzhdmzdubfnxsxhbxkxqcophdvuexqvhmpdhzyruxsgenzlywoplytlvmueeqqvgtbmsuyyxdzotihjuvpnasestnbkijolzcwhjecwqazdaznaqmapknfxamhenjpxrbcpdtaofoxbqrjlqejoyiyadbidupaciyvqxsljwjvuvsbaffiwgywnppdgzyerhxoztdaqbxirvtxujwicmqmbhzldzpnnzyroalgejhjpxugxhtmxtvupuycoytiljujbkuiwridhztwfanslhwmkoyumtczjzdewhqedbthcypsaqcboehwqifmuwtqpnlehqqwqatrewjdwpwxzzygdnemwnemjpfjrlcftscixadecldykuzuqxopacybfnaktstsvdolxsksmldzoucnvddkbwtakqtoxlsnerehkidtsrisushikmzujtctrkzhoyknpopfhehgflunydqrnsvhbrmgxgysbmdyvfjscxfbkjsstvsugdadaozdxygubajszoxqfegnxhxvgautvqjcwxmkbpueaxhfcprhceubnrnyftyojcqaqzqtsshzdqwwcmznigpdjavhsdllistlvaocrcxnuospzaammlizwuagwwgzysnfttechngrpavdqxktguxhddznwiqqqahusbpyyzeoxipltfjupxkslnjslrrofykpxvsyhqzcrrqllolwifsyouyygusbkyumbsfxzfkvmkymeiqkqjvtjmxqsclilqiuwoxauadfmhzmzgbwduxvamfsgqprbvlfvhdblciivhirfpusmaqucvumyfmpnarnmjddvbaewicjcuojhcezmzetibyozesjbjdggjatlkbephkqpmtofyoailpmhujhjjxxbfdvyxucchpvejupcsmyqtwyhxertlxvkylejtwwesuffdbjxatbgijwvvssjhicniivtpukliqtxhjekxuipbzyqhvikwdbcftjdybxvkcbqviolytcjkzpnfxmoqygapkmdiecbverxdhekbcehxbczkruaxbnsbbfqnnauojmfndhadpgdlpcyecovfymuagfqolwpiixuexmkejacoosqmewdkxperanjxyqcrtiepoddoxbpncgqjbvtvfilgaitfdhiqoqprqfutkburhksheyxaiixxdiagybcwroipcbbodzuanvjmldpmqzimcpzouiyxdjabgyucxvonyornokpgsxfgivrgkefkosvswkxctsrpyzmdxyccsjkwsztjjsqehgofofmwxxpihehwackixwquknsxbjtjanicjesellhgmsoslclbrvqjupkmwtnjiepbruilvhuvmcpnlihstwltoyvsnpaqdjytbvxgpzkktrznetrrntyfxwuomdkozdxyghomzzbbsrcbrjoekbnyludqwklberhyvzqnfsjvdfgzeneidnkqdjvibytnbgodbhxusnfqcpdxiumyhzkafasrluokwyhtgibbzcdbefefvwfsfkgkoqmbanwmfpjibtnicvyhhhjthkbjwscvqqdspwnrppfrjqbbywzplqpbbgxeuoucqijidegrbwqnzauppjlnrsbavfnpirfrgptbsgfrwogugdrcvqflgyctcizdkzvpndpfunrmptwzkhbmxfsqytvtuvchoyyozeeybgyaacprhskgdhdgwpsidvjcnxxnkxyhwfvnoenjybimnezpdhuwglcdvbkoriiwbpwfnngfzsvhvgolspzmzdjmmtedphfvbqtwukugmzvlthhtrlhktlgpofdbjcjlezrrztbfvtdmmfpoozrprebbdqgfbogcubyygqajsjcuicbtcgiplcjpobpbjkscejadtmcltlvrioxmyezrixaeheullnjnqermatakdjlapgchhodfjyoramsovjrucoyqwcmzwfviplueakobsphzdvgguemxznqfpkqygcuienalnvognckangawqznacdaizjggzrlyixlmjacmrmdnonfkkunlnjktblqvniufvsiuigjsoxgwvlhpgtzirtitnchhnkjwufirhfryhqmmmrqqkorrhhhalcrkrxteiwwxudokawzavruyezzbkplipnlzqkgydubwsqaievplcgrjgacsxoblgvaexbllwkptxlsnshkvjdgxuciriygxvbxvsvnppxwatcjfeturbdkmfyutrjfrzquffsqtbaiucrnassqttfxvdmnwllznijyebvinmscdecpadomqrzbdalpccpqaablorqkxlhxxsjsvozgreubbkoaqdqswluacjcwqhvboleephyrkbvqzvhkfvjmywuvcbqtfzlrlmhqmcgidzdpbaqhwjefqwkchylugvtebdsfpgryefsikuothvxdirlgjszdhnqjdwglniqyxsmgaxbolytchbkwchbzymofvzezwdqzqqeyadnuehbnemgabzeylinhkmgrqcfgmezpqrdrdzpkyiburgihmghcdymfyebtlygqjkjjzsejryfxoetuqxthjnnszqmtcshsgbwliimbzlwkdwdohfnkssaxaneeuhfbupprvaqcpbjhehvilruvtpdsvxsyipezyjjeinmytgdrxghzvrgrarmubzkjehcdcpuuqoelffsjvmdstdldkicdezzwnyqphtzbsyjdxyrfquekjwdgqenivphasqzfyoghzxgolindorrpomjpteaeqcgpoturvvvmlrjllfdhrjzhosfljyleizhywzgaznkowlmokfknbtwbobkcaelnzibbbugfgkecbwlprzrvetakfxbrohldqcrlusulhykhrwgxhguvcbwtlyxqaankxlfldqiusghbeynaumjkmdhzioduuqlbqzfighgscoumpvimgxweislbmirarfitmxnpvjlvwcwttxtwskhwnsvodzxjmcluwvkifyruajyqkrxgiibxvpmhpexjesqrwxolxdaxdgubhivancgwgycurmianqpbgeixjkkrmfwzmqdltpalhoovsyyoirxzfchsjbdvcmdtdvqhcxigoshlhumknxrfttfoezvkdikobommlturfsfahtftetoepkbrvabybsxsplpdkfegdeoabpdnpccpekwlexkwuvxuyzmungcerodlpxyujqbaakbxiisbgvplpfpgznrjhoqikchepzytfneysxzntofllfxwwwyudqbqlkmtoqphlpyalgakgnclozskgflwfqesyndenixjpawezmexxxuedpayeugmneimbflmqntsgedbozfqdijfgleqbivfypicskjbkeljuwgnnrthlasuxwhvgrkhnlpjiturepscwouioadazvjezmylmpabzcpaadgrjkhzbsypmrnglnhsqmagiiidvfvxzzjwpltnbhampgsolhvybbadzxmfsdrsdwhubuvjoiigwlgyxqnceizrlkiqebfwqlmurcjveqrkdekixumpeuzvwwljonzpfbhhcvwzwvrpezwsyjhvmkqfpoicnyygnstzieqedeelzdqnvoygqoiwxeodltqqgcjkiupxyqfvgvqiujegrtwylkwqcfvpcoxzgnklwdgxgiawpsmqdczgjlsnutgftitomexsyhdfqdekwyuxnholtbhrdxkalneyxashbzyvqhrafrlpwftepbimhadeobtajnjywfqbfinlyfnnzxrsfplijuxsqeuuhragarmpemlrvbcshspnuchitzmyjarlhzzqwzgolfioinzedqlemzwfxfrzzefjqkagdfydsyahwnvagwybxftdrfhumrknkrmozmcjfweugtysefpixtcritelwauclnsxzrtjaazjuhhmluxtpluueavenoqtrjxgkaaoxcqlfcipxnrrfopkeejitegkofqpuhamasfgruufislfsztwnpodovzoumuldxnrggsedcvxveaxmjtclabgqfnogqtmetrztxmtbpyggbogaahmwkkmqgjijeiexvsmekfmwlzvzbbliymyizwdlwnrgisromrphhrhxjwgqweebnrpwzigmihrkwieadpffhmrdhneggccupukoqnskgpsygjibkxkvecoabzzonfwrzhixbsnrxpaabqbjultxwzcmwmjjtqlzosqygchhjftrooexuiviynmjifyzqfhyvnshgwlqavyufnftlpvafebvayqfoaicdtqbonhpurewojheftjgnrbisafbympcvmzcksxyldwrroyhmrikoxxjqpwifznviccfqdcqhfynffkxfqqfmsgwypwqzrfdurbbdtlbqkjzbnvjklxchgqyxvivvdoyzusfkqvitkbffzittcvumbenfncmqwaldnkisolhaxyppskeqpwkhxglzfhaeyfurdmmjepvavmqrghmvkqqhwhmfyzwgafcvflkiswnedfyfkplbpgxeqnghwodexgcevvplkcrgerdufugubvveufglgxncxooyzhsidxafjukyikcszgjyriwvjqgiyjdcfuqstkmscxqdmtowwzwxrgjnrdotvkgshkhdzoipompvsboyybghicwoajvynqmpcrcrifpzemgrsyqhgwaibmzbtuxdbojilgsumeuwrglimcdxqylzmhvqlhuswwnbtpgsgjhngvmgrracuwaefbifpyutkeeqyldrfrxrzakpxhelhesgojnyhduxxdgvmxjeptsdjrgetvulicgwosidrhrldhpfkhybodmliuqquyjmnnndwkyukujxyfgxwmfeewlnvsenroibkbskcvjlwnhdvxzvlafgrbkmektqgqubtkjufauytcqtvddhisrarixopnssztkombeeheclxtvbfjopojmuacsvredylrdmdroevocwpuafrvcwpurkjemphtxbtuterkraquwhewjunczkqifevojpuwhrgahziljtdgamnnefixbzdkpvhppsrqnfsasivawembztecgxbsqpprdmbuvmmpyttrlxhgffjqqukoloofusdvzogydhykpfrokcveompgtiddowbjslngrhxbfdrtfwrxtxxhyqlqtcfvayeijbgrmbsikkjlgjpnqgamyjmigczoydeftmbamhezikrobysdktzxprwtvejebqmrgeqktjtxzecvlttcnasitcdxerbtnnoqphmfclqdjmtmfwtjpduyjfezfqvfhdxrtbcszczbkzvivopuhbigymsmwhtoccnrpnqfesjilzrnonmvayysnmhkqcmzatmkqfhwuuewxfyikknghbllpfkozbqjuatbjabdwjmylhzeswbhixbfucuneksbewewnkouzsqwdhppkikzjjdobffzdgbneiifotyljwfvifuojomokldvbfaylltqqlovajdocomtqbaupnzcvgraotarkbtyjermfmkodsiagfzhvjgqcrtitwiiibwhqgxunofteiezfkjjyxgazrcnjpiycfckbgcekcgxzaaulzrxxjiahsrhmskhagkpqlwsxyoltxlapmcixqrlkyqcsazuwtiopoepzcqdwfgqzulesnzeoqfxlziduryxvivarxyocahvniuqqvzgjlhkkdgiofpufpnbnnuiuyubwuvsglucmldenwmikrnbnvuzxsvwetlftbltadkehxjeolkrcytttevyghpiqdhrsmkcwqrvjmlftxdrmdfdmsuoqjncgfhhanwhoynbameomdiylrtgitjjpmmrgewynrsfbulavjeqyksdsolqgnompvuvyjehxltilsgvkozbqulcjlujnwwmoknaxtomxhezacwqbadunypvleycbrnsooqmraqkxpdvgjqknextveduwmiwfmfapvazjbpmbomboxnwdgycsqdxifogvsienesrdvtmaslzpnuydtwopzossbldzfeqyjgtyfzolcguaezcyiqptbcfiwqlazzifanazzuyafqgylkhipozeubyyavomllkugbiryvmrtfowwkzmnepixhbcvhhwgittieibelltscciwbzrdflfoikfpxemwvqljpeboaoiddnwbrteuitdijlccygoeagaoszjttpzprgcmbzuatflxrlckiuvfvwhucxyvzlhempflbdxobxomqrxkwzkhhzbkwelnklqgceelbviwoubthmcimqsxzfltflmmeovrplbyuflfmfptsftcjefxojspznivilyjhmhyjjrquhsabplbvrzvwjjsestjiwnlxcnsxwpdocakqaermwukdmtebglrhczzuerizmnpesbiqqhvfjdrocjbqovlzkddkhfhkppkjotjjnpxhbrinseothqfzenegsqolrdwqghbgjegnuquibehbvhljqhckwqtlbifychzucbokpwrzuwmymlsauehuvpyhksktgrygwhugmzsdcjwiidgijqzksckhlvwhimvwpcupymxxdmpqbamnyihkegjhnzndnztcvwwaztfwrwhpkfgzjzzumffgnuyzookyumucrelubxfvqjswgbbiejfqcbwelbccobomjziltlooqzaqdsnzomgltagcsupwfdktwwsnnwjsxffujvapiqdqfcalmkcsdxhpdxtkvwcnijcsjodwftgrrppgbqgmnaiwnwziocuuvzdlpaisazreccmzucbmbrzodhoyvkrgnuuwitsybybdmbdflmpsfmfobppmxijebewhrjykayikcjhxxftpsycglqwbtjhpyxsvufflumjeueajtiddkuuuosiannuszoqhzrawqalnrkdtonbroozwjrybvyzedklaoqloqoesdcjfnnfcjosdmlglbqkmxdgcyscwvrpjaonfcjvyysebeeqwuaptkyrcpljexpcoioaicwtummmctcxfinoqedipktljwejuhclyytszzxejmgelzwlmwixeacdbxrtjacgqlgxstetvrsxdctxwdebpvyckxhmnhmlxvyssgppqdekiafsjqkfjsuhunzmfyholfcyingozuupgngcwabxmthkihhvriyynqaipfnyedzyiuyhvzeltwoqvxysiapirhqintmgshniepfiqkqmnfgmuujkboptbuomxqwtiveeiisypefjnmihohhlnexsblnicczmiazyllxwizkxjelafjzvwulldlazmvtsguauabayhiuyngmybmemhdwdpuofthazwliknjjrtzusozdkqupaxbhrcnhjvilnkqufszdztqgnolezliyupcdntxhelpyfmnvmyhzjnhqobptbkqoryawqxhvilbfwxideqxxuhfopyicxukatxkjdcvbutdigdohsdvutbuofcdyiqtawnvvqrfjltoamawjdlbpeacjrvetzbgyyguuefvwmsyjcucnpggrilsjcanrokuflhgbhephtqdmzxsmokceobdoszgekzwencxcbnrculmhsqrtacfocccolipkajsdlgmxdrnyupvljsbsjdgdyxtnuuugdbrfqdrcjwoksyecckbagzryqvjwdhoewpblhspptdblulrazixxfppkytllccowcmxhyxuljlhenccsvfnbmtkfuwsxirkataxvfedhuxpfomssxvxwvycejnjncqlwukuuhvltdiyjosurpsefgtfcdxgmekywxkrtnxivijzracvjhfbpasgejjzarwuzozotgnvmjcyxowzdinrzommmmiahgykyzrenkfijaywunzwyzggopinroqyqytdewmuwufpuldcgdnfozthusuluyaclwjvvzppstdwroczppvyaxaxeahkibfgzibjzxqouectbqzajgzhfiulwozgyfnqdriumdrkrbjgfpbzgutcyhuttfrzguintezksmonckejjaaildcygtnagrwqrxoojkzzabbhqjopxcqlnbejngegudcswsbezmnisdwvxxpfbbftpicjnljqrjfnxyqjshjecsdobqjzmkjmfaycecxnvdxdlolykkmpofhxzzstsyaqkbesiogdgixnlyvxbbyhgpaadvymjhmgktzjjrvjkfejextibukiwwcmddoxikyntzmipegawysqratdvsygcopvwqymmjmtnaomeqylnuvbckpftwvwdrefyieltdfgdidugpfjcgpwnztakgyxplbqnuucsqdogkhiklndmysqumuqrhioeeqfdaaaefmwbkdfrgaiyibjoeimsxcdwepheuocxmeitwopzhnimjjmtvzxstatlisbtxaebygmpmncptwqnkyqmebutyjcxzxppfdfrbmekxurvnsbbpzwhbljxudsrakiryhqbkzrjyiadkiogjihpeqjcdluavfjhfjtyxjwnegkoazwodzyqbdjiycnxofnjdufohdnqdvqeonjsctkdompyhozxdsccghoqqgmioywaxyugqovzxzrbxcjmfniqfdcbemjbyvtycpcdtttuntqnlwyuyoytxqhrqicmzxonyzgbnxqkqokyqgenzczyssnahrjaxlkavydwuvxuvwbzsjodiycighsllrwdzbnseyhubxajzuvvycydkjmzncbeottkuugthkpjeynoenmsguzjhrjbqqkxmffqrsyuqyewbtapdvwvffzvthgziwkrscfvbhqvtwdlqugyrbuqbyumkadkyajovcsgfuwurudzutkflrwfzjhopzcwfxlbuycitrltkwfgxlafdgwvaybzlagfmgspqygplkoslmsspiqyswadhwibhwqgcuhcufxtywpwzovwlsresfixwjpacmhvoydklhjiwsykgybtrqdyvqyzbuyeuakvcwjzleflmyomykwruqcuehmiyawnhdlvzjgciypovncbevhyysolncerfemqoyufcqngpzcjrrflykvmfunwwzvgneiikaihqdrfirhmipwqsocfxxhmzeamgesapihbnwjhxydsidugjroxfkdcriqbpirntogonwilexdjljswzzjzupldnmmgnaqposwpszwiwrquolxkjfwoulxpfevrnflcpuwmzpjlzrczembfjiunfsjpxxovopohxxjgmctiyufmpwrsnlxuswduufpiwrfsygrxjqvxrojhmqiqatxoyrrqskalhwgbsiegufutqizqokjivkeswvffoabgpymkapfiuujmzqjgasozeqwjorevubweqjzraxhfgbldcctwxkbenfoltcjafhtxzsuslmpuygmugrkbyapkwqfkgnezqtckeibkhwaguvsbsipnbtzouhpnndxmtwigmhayqrpzikrhcohhuqrtjdxyxzcfmemaityvmfckmukyphuturiylxgiblpbmowqovzvrevryucnvghbpluizimddxvufzwjedvqukqacesbvsjphcpjljekitwcdaneyodtwvqyzzjtgbcvizvrkcijdnxhblyepfifgtpfxthhklnlfulxsywzsruzqmcicrtkmgmiabvwfwwewwpazlgskknaghyvxrewvjrgfbrzsawxhaglmybarreirnynoypqqgrabrmdugedmkinbcawjvwbhyysbjqrczhqlhagidbfhpgjgowlcggljwgblizsggbqsnkjlvjeqlfcraixdhjomvgmbjepkhifqzagmqflykmnqrgymwnqpuanzzjkelsvkrddwtdjikqgctudfwtabbxmyvumodcsgnmgwqlojrhkqttqskphtixhwebigxkhsauioofhgysgriuyttzlriefznaexrsibegiiuehtaunpbwfyjgrafwfthezggvyibebydqzbmvxdmlmavkpurjpnnrdclujqpethrjbvmnedlanilobzccbvrrnnnokzxziioryoqaekrlywnddwrpfavjgpjljzbougkofbxnoaorzbhpausknolgtdajdbavwfphawajbycqrvaavweuxznahioaubliprvlhewbxbvecaovnfywjtqudzjgcqomquzaeijuetzntpyurcodroikykftcvybofbibhdesxnuggrlbmxxvatxzprsvkwkjvplkuszqwhnlzwqxctoyweudvufieubzrmouclseafxcfcpnensuefrrlwsjihzxsjomvyuzxu";
            Debug.WriteLine("length:" + test.Length.ToString());
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            ret = s.LongestDupSubstring(test);
            sw.Stop();
            double a = sw.Elapsed.TotalSeconds;
            Debug.WriteLine("a speed:" + a.ToString());
            sw.Restart();
            ret = s.LongestDupSubstring3(test);
            sw.Stop();
            double b = sw.Elapsed.TotalSeconds;
            Debug.WriteLine("b speed:" + b.ToString());
            Debug.WriteLine("b/a:" + (b / a).ToString());
        }

        public class Solution
        {
            //Rabin–Karp algorithm, https://zh.wikipedia.org/wiki/%E6%8B%89%E5%AE%BE-%E5%8D%A1%E6%99%AE%E7%AE%97%E6%B3%95
            public string LongestDupSubstring(string s)
            {
                var lds = string.Empty;
                var n = s.Length;

                var left = 1;
                var right = n;
                while (left <= right)
                { //O(Log n)
                    var mid = left + (right - left) / 2;

                    var dup = GetDup(mid, s);
                    if (dup != null)
                    {
                        lds = dup;
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                return lds;
            }

            private string GetDup(int mid, string s)
            {
                var hash = Hash(s.Substring(0, mid));

                var set = new HashSet<long> { hash };

                var pow = 1L;
                for (var i = 1; i < mid; i++)
                    pow *= 31;

                var n = s.Length;
                for (var i = 0; i < n - mid; ++i)
                { //O(n)
                    hash = NextHash(pow, hash, s[i], s[i + mid]);
                    if (!set.Add(hash))
                        return s.Substring(i + 1, mid);
                }

                return null;
            }

            private string GetDup2(int mid, string s)
            {
                Dictionary<string, int> map = new Dictionary<string, int>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (i + mid > s.Length)
                    {
                        break;
                    }

                    string str = s.Substring(i, mid);
                    if (map.ContainsKey(str))
                    {
                        return str;
                    }
                    else
                    {
                        map[str] = 1;
                    }
                }

                return null;
            }

            private string GetDup3(int mid, string s)
            {
                Dictionary<long, int> map = new Dictionary<long, int>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (i + mid > s.Length)
                    {
                        break;
                    }

                    string str = s.Substring(i, mid);
                    long hash = Hash(str);
                    if (map.ContainsKey(hash))
                    {
                        return str;
                    }
                    else
                    {
                        map[hash] = 1;
                    }
                }

                return null;
            }

            private string GetDup4(int mid, string s)
            {
                var set = new HashSet<long>();
                for (int i = 0; i < s.Length; i++)
                {
                    if (i + mid > s.Length)
                    {
                        break;
                    }

                    string str = s.Substring(i, mid);
                    long hash = Hash(str);
                    if (!set.Add(hash))
                    {
                        return str;
                    }
                }

                return null;
            }

            private string GetDup5(int mid, string s)
            {
                var hash = Hash(s.Substring(0, mid));

                var set = new Dictionary<long, int>();
                set.Add(hash, 1);

                var pow = 1L;
                for (var i = 1; i < mid; i++)
                    pow *= 31;

                var n = s.Length;
                for (var i = 0; i < n - mid; ++i)
                { //O(n)
                    hash = NextHash(pow, hash, s[i], s[i + mid]);
                    if (set.ContainsKey(hash))
                        return s.Substring(i + 1, mid);
                    else
                        set.Add(hash, 1);
                }

                return null;
            }

            int total = 0;
            private long Hash(string s)
            {
                var h = 0L;
                var a = 1L;

                var n = s.Length;
                for (var k = n; k >= 1; k--)
                {
                    var ch = s[k - 1];
                    h += (ch - 'a' + 1) * a;
                    a *= 31;
                }
                total++;
                return h;
            }

            //https://zh.wikipedia.org/wiki/%E6%8B%89%E5%AE%BE%E6%8C%87%E7%BA%B9
            private long NextHash(long pow, long hash, char left, char right)
            {
                total++;
                return (hash - (left - 'a' + 1) * pow) * 31 + (right - 'a' + 1);
            }

            // time limit exceeded
            public string LongestDupSubstring2(string s)
            {
                string ret = "";

                Dictionary<string, int> map = new System.Collections.Generic.Dictionary<string, int>();
                int cnt = 0;
                for (int j = s.Length - 1; j > 0; j--)
                {
                    //for (int j = 1; j < s.Length; j++)
                    for (int i = 0; i < s.Length; i++)
                    {
                        cnt++;
                        int len = i + j;
                        if (len > s.Length)
                        {
                            break;
                        }
                        string str = s.Substring(i, j);
                        if (map.ContainsKey(str))
                        {
                            return str;
                            //if (str.Length > ret.Length)
                            //{
                            //    ret = str;
                            //}
                        }
                        else
                        {
                            map[str] = 1;
                        }
                    }
                }

                return ret;
            }

            //out of memory
            public string LongestDupSubstring3(string s)
            {
                string ret = "";

                Dictionary<string, int> map = new System.Collections.Generic.Dictionary<string, int>();
                int cnt = 0;

                int left = 1;
                int right = s.Length - 1;
                int len = (left + right + 1) / 2;
                while (len > 0 && len < s.Length)
                {
                    map.Clear();
                    bool exist = false;
                    for (int i = 0; i < s.Length; i++)
                    {
                        cnt++;
                        if (i + len > s.Length)
                        {
                            break;
                        }

                        string str = s.Substring(i, len);
                        if (map.ContainsKey(str))
                        {
                            ret = str;
                            exist = true;
                            break;
                        }
                        else
                        {
                            map[str] = 1;
                        }
                    }
                    if (left >= right)
                    {
                        break;
                    }
                    if (exist)
                    {
                        left = len + 1;
                    }
                    else
                    {
                        right = len - 1;
                    }
                    len = (left + right + 1) / 2;
                }

                return ret;
            }

        }
    }
}
