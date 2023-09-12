namespace ConvertJS.DTOs.ResponseDTO
{
    public class AdSpyResponseDTO
    {

       
            public int __ar { get; set; }
            public Payload payload { get; set; }
            public Jsmods jsmods { get; set; }
            public Hsrp hsrp { get; set; }
            public string[] allResources { get; set; }
            public string lid { get; set; }
        }

        public class Payload
        {
            public bool isResultComplete { get; set; }
            public Result[][] results { get; set; }
            public object[] pageResults { get; set; }
            public string forwardCursor { get; set; }
            public string backwardCursor { get; set; }
            public int totalCount { get; set; }
            public string collationToken { get; set; }
        }

        public class Result
        {
            public string adid { get; set; }
            public string adArchiveID { get; set; }
            public object[] archiveTypes { get; set; }
            public int[] categories { get; set; }
            public int? collationCount { get; set; }
            public long? collationID { get; set; }
            public string currency { get; set; }
            public int endDate { get; set; }
            public string entityType { get; set; }
            public object fevInfo { get; set; }
            public string gatedType { get; set; }
            public bool hasUserReported { get; set; }
            public bool hiddenSafetyData { get; set; }
            public string hideDataStatus { get; set; }
            public Impressionswithindex impressionsWithIndex { get; set; }
            public bool isAAAEligible { get; set; }
            public bool isActive { get; set; }
            public bool isProfilePage { get; set; }
            public string pageID { get; set; }
            public object pageInfo { get; set; }
            public bool pageIsDeleted { get; set; }
            public string pageName { get; set; }
            public object[] politicalCountries { get; set; }
            public object reachEstimate { get; set; }
            public object reportCount { get; set; }
            public Snapshot snapshot { get; set; }
            public object spend { get; set; }
            public int startDate { get; set; }
            public object stateMediaRunLabel { get; set; }
            public string[] publisherPlatform { get; set; }
            public object[] menuItems { get; set; }
        }

        public class Impressionswithindex
        {
            public object impressionsText { get; set; }
            public int impressionsIndex { get; set; }
        }

        public class Snapshot
        {
            public object ad_creative_id { get; set; }
            public Card[] cards { get; set; }
            public Body_Translations body_translations { get; set; }
            public object byline { get; set; }
            public string caption { get; set; }
            public string cta_text { get; set; }
            public Dynamic_Item_Flags dynamic_item_flags { get; set; }
            public int? dynamic_versions { get; set; }
            public object[] edited_snapshots { get; set; }
            public string effective_authorization_category { get; set; }
            public object[] _event { get; set; }
            public object[] extra_images { get; set; }
            public object[] extra_links { get; set; }
            public object[] extra_texts { get; set; }
            public object[] extra_videos { get; set; }
            public object[] instagram_shopping_products { get; set; }
            public string display_format { get; set; }
            public string title { get; set; }
            public string link_description { get; set; }
            public string link_url { get; set; }
            public string page_welcome_message { get; set; }
            public object[] images { get; set; }
            public Video[] videos { get; set; }
            public int creation_time { get; set; }
            public long page_id { get; set; }
            public string page_name { get; set; }
            public string page_profile_picture_url { get; set; }
            public Page_Categories page_categories { get; set; }
            public string page_entity_type { get; set; }
            public bool page_is_profile_page { get; set; }
            public string instagram_actor_name { get; set; }
            public string instagram_profile_pic_url { get; set; }
            public string instagram_url { get; set; }
            public string instagram_handle { get; set; }
            public bool is_reshared { get; set; }
            public int version { get; set; }
            public Body body { get; set; }
            public object brazil_tax_id { get; set; }
            public object branded_content { get; set; }
            public string current_page_name { get; set; }
            public object disclaimer_label { get; set; }
            public int page_like_count { get; set; }
            public string page_profile_uri { get; set; }
            public bool page_is_deleted { get; set; }
            public object root_reshared_post { get; set; }
            public string cta_type { get; set; }
            public object additional_info { get; set; }
            public object ec_certificates { get; set; }
            public object country_iso_code { get; set; }
            public object instagram_branded_content { get; set; }
        }

        public class Body_Translations
        {
        }

        public class Dynamic_Item_Flags
        {
            public object[] _0 { get; set; }
            public object[] _1 { get; set; }
            public object[] _2 { get; set; }
            public object[] _3 { get; set; }
            public object[] _4 { get; set; }
            public object[] _5 { get; set; }
            public object[] _5733360366776274 { get; set; }
            public object[] _5977479055697654 { get; set; }
            public object[] _6268244613241222 { get; set; }
            public object[] _6480588968638490 { get; set; }
        }

        public class Page_Categories
        {
            public string _2707 { get; set; }
            public string _185127444860544 { get; set; }
            public string _210979565595898 { get; set; }
            public string _187937741228885 { get; set; }
            public string _155136917876965 { get; set; }
            public string _203743122984241 { get; set; }
            public string _192686080759400 { get; set; }
            public string _2239 { get; set; }
        }

        public class Body
        {
            public Context context { get; set; }
            public Markup markup { get; set; }
            public string callerHash { get; set; }
        }

        public class Context
        {
        }

        public class Markup
        {
            public string __html { get; set; }
        }

        public class Card
        {
            public string original_image_url { get; set; }
            public string resized_image_url { get; set; }
            public string watermarked_resized_image_url { get; set; }
            public string body { get; set; }
            public string caption { get; set; }
            public string cta_type { get; set; }
            public string cta_text { get; set; }
            public string title { get; set; }
            public string link_description { get; set; }
            public string link_url { get; set; }
            public Image_Crops image_crops { get; set; }
            public object video_hd_url { get; set; }
            public object video_sd_url { get; set; }
            public object video_preview_image_url { get; set; }
            public object watermarked_video_hd_url { get; set; }
            public object watermarked_video_sd_url { get; set; }
        }

        public class Image_Crops
        {
        }

        public class Video
        {
            public string video_hd_url { get; set; }
            public string video_sd_url { get; set; }
            public string watermarked_video_sd_url { get; set; }
            public string watermarked_video_hd_url { get; set; }
            public string video_preview_image_url { get; set; }
        }

        public class Jsmods
        {
            public object[][] define { get; set; }
            public object[][] require { get; set; }
        }

        public class Hsrp
        {
            public Hsdp hsdp { get; set; }
            public Hblp hblp { get; set; }
        }

        public class Hsdp
        {
            public Clpdata clpData { get; set; }
            public Gkxdata gkxData { get; set; }
        }

        public class Clpdata
        {
            public _1838142 _1838142 { get; set; }
            public _1848815 _1848815 { get; set; }
        }

        public class _1838142
        {
            public int r { get; set; }
            public int s { get; set; }
        }

        public class _1848815
        {
            public int r { get; set; }
            public int s { get; set; }
        }

        public class Gkxdata
        {
            public _708253 _708253 { get; set; }
            public _1073500 _1073500 { get; set; }
            public _1167394 _1167394 { get; set; }
            public _1224637 _1224637 { get; set; }
            public _1263340 _1263340 { get; set; }
            public _1857581 _1857581 { get; set; }
        }

        public class _708253
        {
            public bool result { get; set; }
            public string hash { get; set; }
        }

        public class _1073500
        {
            public bool result { get; set; }
            public string hash { get; set; }
        }

        public class _1167394
        {
            public bool result { get; set; }
            public string hash { get; set; }
        }

        public class _1224637
        {
            public bool result { get; set; }
            public string hash { get; set; }
        }

        public class _1263340
        {
            public bool result { get; set; }
            public string hash { get; set; }
        }

        public class _1857581
        {
            public bool result { get; set; }
            public string hash { get; set; }
        }

        public class Hblp
        {
            public Consistency consistency { get; set; }
            public Rsrcmap rsrcMap { get; set; }
            public Compmap compMap { get; set; }
        }

        public class Consistency
        {
            public int rev { get; set; }
        }

        public class Rsrcmap
        {
            public _3Oxgy9p _3OxGy9p { get; set; }
            public Eke4cr2 EKe4Cr2 { get; set; }
            public Mynesok MyNESOK { get; set; }
            public Azxjz6g aZxJZ6g { get; set; }
            public _0Bj1l9r _0Bj1L9r { get; set; }
            public Voubwmi vOUBWMI { get; set; }
            public B7iopo0 B7iopo0 { get; set; }
            public DawnzS dAWNZs { get; set; }
            public TljdAw TlJDaw { get; set; }
            public G7rbrzk G7RBrzk { get; set; }
            public Xlmd9qk XLMD9qK { get; set; }
            public R1Tz5m R1TZ5m { get; set; }
            public H246k3z h246K3Z { get; set; }
            public Emtnqvv EmtnQVV { get; set; }
            public Lzkajhx lzKajHx { get; set; }
            public Epzamsv epzAmsv { get; set; }
            public Rh3wtjr rh3wTjR { get; set; }
            public Yhw4mtr yhW4mTr { get; set; }
            public Rtmaaqd rtmaAqd { get; set; }
            public _2Kbewn _2kBewn { get; set; }
            public R5w1rcj R5w1rCJ { get; set; }
            public Eunhuiq EUnHuiq { get; set; }
            public Zaiopl5 ZaIopL5 { get; set; }
            public I4jklkp I4jKLKP { get; set; }
            public Lfxay6a Lfxay6a { get; set; }
            public Axabkqi AxaBKqI { get; set; }
            public YyuWek yyuwek { get; set; }
            public Gj2Nx gj2Nx { get; set; }
            public GjpydG gJpYDg { get; set; }
            public Rm3pnqd rm3pnqd { get; set; }
            public Cdgz3me cdgZ3Me { get; set; }
            public Ehtg4tx EhtG4tx { get; set; }
            public Bf7kSg bf7ksg { get; set; }
            public Ehtjzow EhtjZOW { get; set; }
            public M7Jlcr M7jlCR { get; set; }
            public Utssfli UtssFLi { get; set; }
            public Fvffqxj FvffQXJ { get; set; }
            public Kuoewiz kUOEwiZ { get; set; }
            public Vrmt6jy vRmt6jY { get; set; }
            public Ktu0vc7 KTU0Vc7 { get; set; }
            public _27P8hat _27P8hAt { get; set; }
            public _8Elcbwh _8ELCBwH { get; set; }
            public X22oby4 x22Oby4 { get; set; }
            public Ysoblx ySoBlX { get; set; }
            public Swx3ynv SWx3yNv { get; set; }
            public Oe4doft oE4DofT { get; set; }
            public H5Lfuf H5lfuF { get; set; }
            public Qiamfde QIamfde { get; set; }
            public Vhqunvl VhquNVl { get; set; }
            public _161Swvx _161SwvX { get; set; }
            public _9Niatan _9NiATAn { get; set; }
            public Lrlr28u lRlr28U { get; set; }
        }

        public class _3Oxgy9p
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Eke4cr2
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Mynesok
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Azxjz6g
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class _0Bj1l9r
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Voubwmi
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class B7iopo0
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class DawnzS
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class TljdAw
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class G7rbrzk
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Xlmd9qk
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class R1Tz5m
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class H246k3z
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Emtnqvv
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Lzkajhx
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Epzamsv
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Rh3wtjr
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Yhw4mtr
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Rtmaaqd
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class _2Kbewn
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class R5w1rcj
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Eunhuiq
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Zaiopl5
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class I4jklkp
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Lfxay6a
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Axabkqi
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class YyuWek
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Gj2Nx
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class GjpydG
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Rm3pnqd
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Cdgz3me
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Ehtg4tx
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Bf7kSg
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Ehtjzow
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class M7Jlcr
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Utssfli
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Fvffqxj
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Kuoewiz
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Vrmt6jy
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Ktu0vc7
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class _27P8hat
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class _8Elcbwh
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class X22oby4
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Ysoblx
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Swx3ynv
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Oe4doft
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class H5Lfuf
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Qiamfde
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Vhqunvl
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class _161Swvx
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class _9Niatan
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Lrlr28u
        {
            public string type { get; set; }
            public string src { get; set; }
        }

        public class Compmap
        {
            public Dialog Dialog { get; set; }
            public Exceptiondialog ExceptionDialog { get; set; }
            public Quicksandsolver QuickSandSolver { get; set; }
            public Confirmationdialog ConfirmationDialog { get; set; }
            public Mwadeveloperreauthbarrier MWADeveloperReauthBarrier { get; set; }
            public Webspeedinteractionstypedlogger WebSpeedInteractionsTypedLogger { get; set; }
            public Perfxsharedfields PerfXSharedFields { get; set; }
        }

        public class Dialog
        {
            public string[] r { get; set; }
            public Rds rds { get; set; }
            public int be { get; set; }
        }

        public class Rds
        {
            public string[] m { get; set; }
        }

        public class Exceptiondialog
        {
            public string[] r { get; set; }
            public Rds1 rds { get; set; }
            public int be { get; set; }
        }

        public class Rds1
        {
            public string[] m { get; set; }
        }

        public class Quicksandsolver
        {
            public string[] r { get; set; }
            public Rds2 rds { get; set; }
            public int be { get; set; }
        }

        public class Rds2
        {
            public string[] m { get; set; }
        }

        public class Confirmationdialog
        {
            public string[] r { get; set; }
            public int be { get; set; }
        }

        public class Mwadeveloperreauthbarrier
        {
            public string[] r { get; set; }
            public int be { get; set; }
        }

        public class Webspeedinteractionstypedlogger
        {
            public string[] r { get; set; }
            public int be { get; set; }
        }

        public class Perfxsharedfields
        {
            public string[] r { get; set; }
            public int be { get; set; }
        }

    
}
