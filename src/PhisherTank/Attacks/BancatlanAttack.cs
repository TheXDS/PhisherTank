using TheXDS.PhisherTank.Models;

namespace TheXDS.PhisherTank.Attacks;

internal class BancatlanAttack : LiveBlog365AttackFamily
{
    public BancatlanAttack() : base("bancatlantrustt.liveblog365.com")
    {
    }

    public override IEnumerable<AttackItem> GetAttacks(IAttackContext context)
    {
        context.AddCommonBrowserHeaders();
        yield return new("");
        GetCookie(context);
        context.AddReferrer();
        yield return new("?i=1");
        context.AddReferrer();
        yield return new("mpa.php")
        {
            FormItems = f => new[]
            {
                ("taka", f.Email),
                ("teke", f.Password)
            }
        };
        var pureCookie = context.Headers["Cookie"];
        context.Headers["Referer"] = "http://bancatlantrustt.liveblog365.com/index2.html";
        context.Headers["Cookie"] = $"{pureCookie}; dtCookie=v_4_srv_-2D9_sn_M8ME7O1SNFGPMQEBREOPMOK1Q4M5FIP2; rxVisito" +
            $"r=1692031207716F3F9LNCO1INR7V9JG078REG6V4P6P9A7; dtPC=-9$31207713_250h1vOGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-" +
            $"0e0; dtLatC=2; dtSa=-; rxvt=1692033009987|1692031207717";
        yield return new("ocbretail/rb_2f4942fa-a829-48bb-b04d-dc604b453513?type=js3&sn=v_4_srv_-2D9_sn_M8ME7O1SNFGPMQE" +
            "BREOPMOK1Q4M5FIP2&svrid=-9&flavor=post&vi=OGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0&modifiedSince=1691173329539&r" +
            "f=http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html&bp=3&app=54d2e0bdb86aa8c4&crc=3037917525&en=o" +
            "thww5w2&end=1")
        {
            PlainData = _ => "$a=1%7C1%7C_load_%7C_load_%7C-%7C1692031205644%7C0%7Cdn%7C-1%7Csvtrg%7C1%7Csvm%7Ci1%5Esk0%" +
            "5Esh0%7Clr%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%2C2%7C2%7Cui5loader-autoconfig.js%3A%" +
            "20could%20not%20determine%20base%20URL.%20No%20known%20script%20tag%20and%20no%20configuration%20found%21%" +
            "7C_error_%7C-%7C1692031209981%7C1692031209981%7Cdn%7C-1%2C3%7C3%7CError%7C_type_%7C-%7C1692031209983%7C169" +
            "2031209983%7Cdn%7C-1%2C3%7C4%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_files%2Fsap-ui-core.j" +
            "s.descarga%5Ep2094%5Ep33%7C_location_%7C-%7C1692031209985%7C1692031209985%7Cdn%7C-1%2C3%7C5%7CError%3A%20u" +
            "i5loader-autoconfig.js%3A%20could%20not%20determine%20base%20URL.%20No%20known%20script%20tag%20and%20no%2" +
            "0configuration%20found%21%5Ep%20%20%20%20at%20http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_files%" +
            "2Fsap-ui-core.js.descarga%3A139%3A522%5Ep%20%20%20%20at%20http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Fi" +
            "ndex2_files%2Fsap-ui-core.js.descarga%3A144%3A5594%7C_stack_%7C-%7C1692031209985%7C1692031209985%7Cdn%7C-1" +
            "%2C3%7C6%7C2268%7C_ts_%7C-%7C1692031209986%7C1692031209986%7Cdn%7C-1%2C3%7C7%7C1%7C_source_%7C-%7C16920312" +
            "09987%7C1692031209987%7Cdn%7C-1$dO=bancatlantrustt.liveblog365.com,bancatlan.hn$PV=1$rId=RID_54233326$rpId" +
            "=1256470564$url=http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html$title=Atl%C3%A1ntida%20Online$l" +
            "atC=2$app=54d2e0bdb86aa8c4$vi=OGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0$fId=31207713_250$v=10257221222094147$time" +
            "=1692031215766"
        };
        context.Headers["Cookie"] = $"{pureCookie}; dtCookie=v_4_srv_-2D9_sn_M8ME7O1SNFGPMQEBREOPMOK1Q4M5FIP2; rxVisito" +
            $"r=1692031207716F3F9LNCO1INR7V9JG078REG6V4P6P9A7; dtLatC=2; dtSa=-; rxvt=1692033033441|1692031207717; dtPC" +
            $"=-9$31207713_250h-vOGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0e0";
        yield return new("ocbretail/rb_2f4942fa-a829-48bb-b04d-dc604b453513?type=js3&sn=v_4_srv_-2D9_sn_M8ME7O1SNFGPMQE" +
            "BREOPMOK1Q4M5FIP2&svrid=-9&flavor=post&vi=OGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0&modifiedSince=1691173329539&r" +
            "f=http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html&bp=3&app=54d2e0bdb86aa8c4&crc=756952484&en=ot" +
            "hww5w2&end=1")
        {
            PlainData = _ => "$a=1%7C1%7C_load_%7C_load_%7C-%7C1692031205644%7C1692031233443%7Cdn%7C238%7Csvtrg%7C1%7Cs" +
            "vm%7Ci1%5Esk0%5Esh0%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%7Clr%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com" +
            "%2F%3Fi%3D1%2C2%7C14%7C_event_%7C1692031232368%7C_csprv_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.live" +
            "blog365.com%2Findex2.html%7Creferrer%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedUR" +
            "L%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Fimg%2Flogo%2Flogo_5Fbanco_5Fsingle_5Fred_5Fgradient.svg" +
            "%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Cimg-src%20%27self%27%20https%3A%2F%2Fwww.bancatlan.hn%2" +
            "0https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5Es%20script-src%20%27self%27%20%27u...%7Cdisposition%7" +
            "Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C2%7C22%7C_event_%7C1692031205644%7C_vc_%7" +
            "CV%7C27796%5Epc%7CVCD%7C1038%7CVCDS%7C1%7CVCS%7C27854%7CVCO%7C28855%7CVCI%7C0%7CVE%7C340%5Ep65%5Ep184240%5" +
            "Eps%5Es%23loginComponent---signin--aolSecurityMessage%7CS%7C26394%2C2%7C23%7C_event_%7C1692031205644%7C_wv" +
            "_%7ClcpE%7CSPAN%7ClcpSel%7C%23__button0-img%7ClcpS%7C500%7ClcpT%7C26387%7ClcpU%7C-%7ClcpLT%7C0%7Cfcp%7C263" +
            "70%7Cfp%7C26370%7Ccls%7C0.0152%7Clt%7C0%2C2%7C2%7Cui5loader-autoconfig.js%3A%20could%20not%20determine%20b" +
            "ase%20URL.%20No%20known%20script%20tag%20and%20no%20configuration%20found%21%7C_error_%7C-%7C1692031209981" +
            "%7C1692031209981%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C3%7CError%7C_type_%7C-%7C1692031209983" +
            "%7C1692031209983%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C4%7Chttp%3A%2F%2Fbancatlantrustt.liveb" +
            "log365.com%2Findex2_files%2Fsap-ui-core.js.descarga%5Ep2094%5Ep33%7C_location_%7C-%7C1692031209985%7C16920" +
            "31209985%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C5%7CError%3A%20ui5loader-autoconfig.js%3A%20co" +
            "uld%20not%20determine%20base%20URL.%20No%20known%20script%20tag%20and%20no%20configuration%20found%21%5Ep%" +
            "20%20%20%20at%20http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_files%2Fsap-ui-core.js.descarga%3A13" +
            "9%3A522%5Ep%20%20%20%20at%20http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_files%2Fsap-ui-core.js.d" +
            "escarga%3A144%3A5594%7C_stack_%7C-%7C1692031209985%7C1692031209985%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%" +
            "5Esh0%2C3%7C6%7C2268%7C_ts_%7C-%7C1692031209986%7C1692031209986%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Es" +
            "h0%2C3%7C7%7C1%7C_source_%7C-%7C1692031209987%7C1692031209987%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0" +
            "%2C2%7C8%7Csap.ui.getCore%20is%20not%20a%20function%7C_error_%7C-%7C1692031228889%7C1692031228889%7Cdn%7C-" +
            "1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C9%7CTypeError%7C_type_%7C-%7C1692031228891%7C1692031228891%7Cdn" +
            "%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C10%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2." +
            "html%5Ep121%5Ep20%7C_location_%7C-%7C1692031228891%7C1692031228891%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%" +
            "5Esh0%2C3%7C11%7CTypeError%3A%20sap.ui.getCore%20is%20not%20a%20function%5Ep%20%20%20%20at%20http%3A%2F%2F" +
            "bancatlantrustt.liveblog365.com%2Findex2.html%3A121%3A20%7C_stack_%7C-%7C1692031228892%7C1692031228892%7Cd" +
            "n%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C12%7C21176%7C_ts_%7C-%7C1692031228893%7C1692031228893%7Cdn" +
            "%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C13%7C1%7C_source_%7C-%7C1692031228893%7C1692031228893%7Cdn%" +
            "7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C2%7C15%7C_onload_%7C_load_%7C-%7C1692031233443%7C1692031233443%7" +
            "Cdn%7C238%7Csvtrg%7C1%7Csvm%7Ci1%5Esk0%5Esh0%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C1%7C16%7C_event_%7C16920" +
            "31233448%7C_csprv_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7Creferrer%7" +
            "Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedURL%7Chttps%3A%2F%2Faolweb.bancatlan.hn%" +
            "2Focbretail%2Ffavicon.ico%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Cimg-src%20%27self%27%20https%3" +
            "A%2F%2Fwww.bancatlan.hn%20https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5Es%20script-src%20%27self%27%" +
            "20%27u...%7Cdisposition%7Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C1%7C17%7C_event_" +
            "%7C1692031233449%7C_csprv_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7Cre" +
            "ferrer%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedURL%7Chttps%3A%2F%2Faolweb.banca" +
            "tlan.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-32x32.png%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Cimg" +
            "-src%20%27self%27%20https%3A%2F%2Fwww.bancatlan.hn%20https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5Es" +
            "%20script-src%20%27self%27%20%27u...%7Cdisposition%7Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5Es" +
            "k0%5Esh0%2C1%7C18%7C_event_%7C1692031233450%7C_csprv_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.liveblo" +
            "g365.com%2Findex2.html%7Creferrer%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedURL%7" +
            "Chttps%3A%2F%2Faolweb.bancatlan.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-16x16.png%7CeffectiveDirective%7Cimg" +
            "-src%7CoriginalPolicy%7Cimg-src%20%27self%27%20https%3A%2F%2Fwww.bancatlan.hn%20https%3A%2F%2Ffontmetrics." +
            "net%20blob%3A%20data%3A%5Es%20script-src%20%27self%27%20%27u...%7Cdisposition%7Cenforce%7CstatusCode%7C200" +
            "%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C1%7C19%7C_event_%7C1692031233450%7C_csprv_%7CdocumentURL%7Chttp%3A%2" +
            "F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7Creferrer%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.co" +
            "m%2F%3Fi%3D1%7CblockedURL%7Chttps%3A%2F%2Faolweb.bancatlan.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-96x96.png" +
            "%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Cimg-src%20%27self%27%20https%3A%2F%2Fwww.bancatlan.hn%2" +
            "0https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5Es%20script-src%20%27self%27%20%27u...%7Cdisposition%7" +
            "Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C1%7C20%7C_event_%7C1692031233451%7C_csprv" +
            "_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7Creferrer%7Chttp%3A%2F%2Fban" +
            "catlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedURL%7Chttps%3A%2F%2Faolweb.bancatlan.hn%2Focbretail%2Fimg" +
            "%2Ficon%2Ffavicon-128.png%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Cimg-src%20%27self%27%20https%3" +
            "A%2F%2Fwww.bancatlan.hn%20https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5Es%20script-src%20%27self%27%" +
            "20%27u...%7Cdisposition%7Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C1%7C21%7C_event_" +
            "%7C1692031233451%7C_csprv_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7Cre" +
            "ferrer%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedURL%7Chttps%3A%2F%2Faolweb.banca" +
            "tlan.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-196x196.png%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Ci" +
            "mg-src%20%27self%27%20https%3A%2F%2Fwww.bancatlan.hn%20https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5" +
            "Es%20script-src%20%27self%27%20%27u...%7Cdisposition%7Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5" +
            "Esk0%5Esh0%2C1%7C24%7C_event_%7C1692031205644%7C_view_%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0$rId=RID_54233326" +
            "$rpId=1256470564$domR=1692031233440$tvn=%2Findex2.html$tvt=1692031205644$tvm=i1%3Bk0%3Bh0$tvtrg=1$w=1920$h" +
            "=951$sw=1920$sh=1080$nt=a0b1692031205644c5d381e381f381g381h381i381k384l609m610o26358p26358q26359r27796s277" +
            "99t27799u8662v8362w42925$ni=4g|1.4$url=http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html$title=At" +
            "l%C3%A1ntida%20Online$latC=2$app=54d2e0bdb86aa8c4$vi=OGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0$fId=31207713_250$v" +
            "=10257221222094147$vID=1692031207716F3F9LNCO1INR7V9JG078REG6V4P6P9A7$nV=1$nVAT=1$time=1692031234544"
        };

        context.Headers["Cookie"] = $"{pureCookie}; dtCookie=v_4_srv_-2D9_sn_M8ME7O1SNFGPMQEBREOPMOK1Q4M5FIP2; rxVisito" +
            $"r=1692031207716F3F9LNCO1INR7V9JG078REG6V4P6P9A7; dtLatC=2; dtSa=-; rxvt=1692033033441|1692031207717; dtPC" +
            $"=-9$31207713_250h-vOGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0e0";
        yield return new("ocbretail/rb_2f4942fa-a829-48bb-b04d-dc604b453513?type=js3&sn=v_4_srv_-2D9_sn_M8ME7O1SNFGPMQE" +
            "BREOPMOK1Q4M5FIP2&svrid=-9&flavor=post&vi=OGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0&modifiedSince=1691173329539&r" +
            "f=http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html&bp=3&app=54d2e0bdb86aa8c4&crc=756952484&en=ot" +
            "hww5w2&end=1")
        {
            PlainData = _ => "$a=1%7C1%7C_load_%7C_load_%7C-%7C1692031205644%7C1692031233443%7Cdn%7C238%7Csvtrg%7C1%7Cs" +
            "vm%7Ci1%5Esk0%5Esh0%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%7Clr%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com" +
            "%2F%3Fi%3D1%2C2%7C14%7C_event_%7C1692031232368%7C_csprv_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.live" +
            "blog365.com%2Findex2.html%7Creferrer%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedUR" +
            "L%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Fimg%2Flogo%2Flogo_5Fbanco_5Fsingle_5Fred_5Fgradient.svg" +
            "%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Cimg-src%20%27self%27%20https%3A%2F%2Fwww.bancatlan.hn%2" +
            "0https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5Es%20script-src%20%27self%27%20%27u...%7Cdisposition%7" +
            "Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C2%7C22%7C_event_%7C1692031205644%7C_vc_%7" +
            "CV%7C27796%5Epc%7CVCD%7C1038%7CVCDS%7C1%7CVCS%7C27854%7CVCO%7C28855%7CVCI%7C0%7CVE%7C340%5Ep65%5Ep184240%5" +
            "Eps%5Es%23loginComponent---signin--aolSecurityMessage%7CS%7C26394%2C2%7C23%7C_event_%7C1692031205644%7C_wv" +
            "_%7ClcpE%7CSPAN%7ClcpSel%7C%23__button0-img%7ClcpS%7C500%7ClcpT%7C26387%7ClcpU%7C-%7ClcpLT%7C0%7Cfcp%7C263" +
            "70%7Cfp%7C26370%7Ccls%7C0.0152%7Clt%7C0%2C2%7C2%7Cui5loader-autoconfig.js%3A%20could%20not%20determine%20b" +
            "ase%20URL.%20No%20known%20script%20tag%20and%20no%20configuration%20found%21%7C_error_%7C-%7C1692031209981" +
            "%7C1692031209981%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C3%7CError%7C_type_%7C-%7C1692031209983" +
            "%7C1692031209983%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C4%7Chttp%3A%2F%2Fbancatlantrustt.liveb" +
            "log365.com%2Findex2_files%2Fsap-ui-core.js.descarga%5Ep2094%5Ep33%7C_location_%7C-%7C1692031209985%7C16920" +
            "31209985%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C5%7CError%3A%20ui5loader-autoconfig.js%3A%20co" +
            "uld%20not%20determine%20base%20URL.%20No%20known%20script%20tag%20and%20no%20configuration%20found%21%5Ep%" +
            "20%20%20%20at%20http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_files%2Fsap-ui-core.js.descarga%3A13" +
            "9%3A522%5Ep%20%20%20%20at%20http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_files%2Fsap-ui-core.js.d" +
            "escarga%3A144%3A5594%7C_stack_%7C-%7C1692031209985%7C1692031209985%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%" +
            "5Esh0%2C3%7C6%7C2268%7C_ts_%7C-%7C1692031209986%7C1692031209986%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Es" +
            "h0%2C3%7C7%7C1%7C_source_%7C-%7C1692031209987%7C1692031209987%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0" +
            "%2C2%7C8%7Csap.ui.getCore%20is%20not%20a%20function%7C_error_%7C-%7C1692031228889%7C1692031228889%7Cdn%7C-" +
            "1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C9%7CTypeError%7C_type_%7C-%7C1692031228891%7C1692031228891%7Cdn" +
            "%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C10%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2." +
            "html%5Ep121%5Ep20%7C_location_%7C-%7C1692031228891%7C1692031228891%7Cdn%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%" +
            "5Esh0%2C3%7C11%7CTypeError%3A%20sap.ui.getCore%20is%20not%20a%20function%5Ep%20%20%20%20at%20http%3A%2F%2F" +
            "bancatlantrustt.liveblog365.com%2Findex2.html%3A121%3A20%7C_stack_%7C-%7C1692031228892%7C1692031228892%7Cd" +
            "n%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C12%7C21176%7C_ts_%7C-%7C1692031228893%7C1692031228893%7Cdn" +
            "%7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C3%7C13%7C1%7C_source_%7C-%7C1692031228893%7C1692031228893%7Cdn%" +
            "7C-1%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C2%7C15%7C_onload_%7C_load_%7C-%7C1692031233443%7C1692031233443%7" +
            "Cdn%7C238%7Csvtrg%7C1%7Csvm%7Ci1%5Esk0%5Esh0%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C1%7C16%7C_event_%7C16920" +
            "31233448%7C_csprv_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7Creferrer%7" +
            "Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedURL%7Chttps%3A%2F%2Faolweb.bancatlan.hn%" +
            "2Focbretail%2Ffavicon.ico%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Cimg-src%20%27self%27%20https%3" +
            "A%2F%2Fwww.bancatlan.hn%20https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5Es%20script-src%20%27self%27%" +
            "20%27u...%7Cdisposition%7Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C1%7C17%7C_event_" +
            "%7C1692031233449%7C_csprv_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7Cre" +
            "ferrer%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedURL%7Chttps%3A%2F%2Faolweb.banca" +
            "tlan.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-32x32.png%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Cimg" +
            "-src%20%27self%27%20https%3A%2F%2Fwww.bancatlan.hn%20https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5Es" +
            "%20script-src%20%27self%27%20%27u...%7Cdisposition%7Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5Es" +
            "k0%5Esh0%2C1%7C18%7C_event_%7C1692031233450%7C_csprv_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.liveblo" +
            "g365.com%2Findex2.html%7Creferrer%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedURL%7" +
            "Chttps%3A%2F%2Faolweb.bancatlan.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-16x16.png%7CeffectiveDirective%7Cimg" +
            "-src%7CoriginalPolicy%7Cimg-src%20%27self%27%20https%3A%2F%2Fwww.bancatlan.hn%20https%3A%2F%2Ffontmetrics." +
            "net%20blob%3A%20data%3A%5Es%20script-src%20%27self%27%20%27u...%7Cdisposition%7Cenforce%7CstatusCode%7C200" +
            "%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C1%7C19%7C_event_%7C1692031233450%7C_csprv_%7CdocumentURL%7Chttp%3A%2" +
            "F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7Creferrer%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.co" +
            "m%2F%3Fi%3D1%7CblockedURL%7Chttps%3A%2F%2Faolweb.bancatlan.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-96x96.png" +
            "%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Cimg-src%20%27self%27%20https%3A%2F%2Fwww.bancatlan.hn%2" +
            "0https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5Es%20script-src%20%27self%27%20%27u...%7Cdisposition%7" +
            "Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C1%7C20%7C_event_%7C1692031233451%7C_csprv" +
            "_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7Creferrer%7Chttp%3A%2F%2Fban" +
            "catlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedURL%7Chttps%3A%2F%2Faolweb.bancatlan.hn%2Focbretail%2Fimg" +
            "%2Ficon%2Ffavicon-128.png%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Cimg-src%20%27self%27%20https%3" +
            "A%2F%2Fwww.bancatlan.hn%20https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5Es%20script-src%20%27self%27%" +
            "20%27u...%7Cdisposition%7Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0%2C1%7C21%7C_event_" +
            "%7C1692031233451%7C_csprv_%7CdocumentURL%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7Cre" +
            "ferrer%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F%3Fi%3D1%7CblockedURL%7Chttps%3A%2F%2Faolweb.banca" +
            "tlan.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-196x196.png%7CeffectiveDirective%7Cimg-src%7CoriginalPolicy%7Ci" +
            "mg-src%20%27self%27%20https%3A%2F%2Fwww.bancatlan.hn%20https%3A%2F%2Ffontmetrics.net%20blob%3A%20data%3A%5" +
            "Es%20script-src%20%27self%27%20%27u...%7Cdisposition%7Cenforce%7CstatusCode%7C200%7Ctvtrg%7C1%7Ctvm%7Ci1%5" +
            "Esk0%5Esh0%2C1%7C24%7C_event_%7C1692031205644%7C_view_%7Ctvtrg%7C1%7Ctvm%7Ci1%5Esk0%5Esh0$rId=RID_54233326" +
            "$rpId=1256470564$domR=1692031233440$tvn=%2Findex2.html$tvt=1692031205644$tvm=i1%3Bk0%3Bh0$tvtrg=1$w=1920$h" +
            "=951$sw=1920$sh=1080$nt=a0b1692031205644c5d381e381f381g381h381i381k384l609m610o26358p26358q26359r27796s277" +
            "99t27799u8662v8362w42925$ni=4g|1.4$url=http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html$title=At" +
            "l%C3%A1ntida%20Online$latC=2$app=54d2e0bdb86aa8c4$vi=OGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0$fId=31207713_250$v" +
            "=10257221222094147$vID=1692031207716F3F9LNCO1INR7V9JG078REG6V4P6P9A7$nV=1$nVAT=1$time=1692031234544"
        };

        context.Headers["Cookie"] = $"{pureCookie}; dtCookie=v_4_srv_-2D9_sn_M8ME7O1SNFGPMQEBREOPMOK1Q4M5FIP2; rxVisito" +
            $"r=1692031207716F3F9LNCO1INR7V9JG078REG6V4P6P9A7; dtLatC=2; dtSa=-; rxvt=1692033033441|1692031207717; dtPC" +
            $"=-9$31207713_250h-vOGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0e0";
        yield return new("ocbretail/rb_2f4942fa-a829-48bb-b04d-dc604b453513?type=js3&sn=v_4_srv_-2D9_sn_M8ME7O1SN" +
            "FGPMQEBREOPMOK1Q4M5FIP2&svrid=-9&flavor=post&vi=OGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0&modifiedSince=169117332" +
            "9539&rf=http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html&bp=3&app=54d2e0bdb86aa8c4&crc=270258415" +
            "2&en=othww5w2&end=1")
        {
            PlainData = _ => "$tvn=%2Findex2.html$tvt=1692031205644$tvm=i1%3Bk0%3Bh0$tvtrg=1$ni=4g|1.4$rt=1-16920312056" +
            "44%3Bhttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Fpreloader.css%7Cb617e0f0g0h0i0k7l161m" +
            "162u744v444w988K1I11%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Fprint.css%7Cb617e0f" +
            "0g0h0i0k9l161m162u803v503w1006K1I11%7Cfile%3A%2F%2F%2FC%3A%2Fxampp%2Fhtdocs%2Fatlanti%2Findex_5Ffiles%2Fco" +
            "rdova.js.descarga%7Cb2085e0m0K1I12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2FAppCo" +
            "nfig.js.descarga%7Cb2085e0f0g0h0i0k3l158m159u2177v1877w3786K1I12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog36" +
            "5.com%2Findex2_5Ffiles%2FConstants.js.descarga%7Cb2247e0f0g0h0i0k3l172m176u5744v5444w12899K1I12%7Chttp%3A%" +
            "2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Fsap-ui-core.js.descarga%7Cb2425e0f0g0h0i0k7l1132m1" +
            "898u218489v218189w689715K1I12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Flibrary-pr" +
            "eload.js.descarga%7Cb4344e0f0g0h0i0k3l2722m4486u542445v542145w1822396K1I12%7Chttp%3A%2F%2Fbancatlantrustt." +
            "liveblog365.com%2Findex2_5Ffiles%2Flibrary-preload.js%281%29.descarga%7Cb8836e0f0g0h0i0k4l3162m8851u212802" +
            "3v2127723w2127723K1I12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Flibrary-preload.j" +
            "s%282%29.descarga%7Cb17692e0f0g0h0i0k3l525m985u263519v263219w263219K1I12%7Chttp%3A%2F%2Fbancatlantrustt.li" +
            "veblog365.com%2Findex2_5Ffiles%2Flibrary-preload.js%283%29.descarga%7Cb18678e0f0g0h0i0k3l1733m3989u1107222" +
            "v1106922w1106922K1I12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Flibrary-preload.js" +
            "%284%29.descarga%7Cb22669e0f0g0h0i0k4l182m183u13991v13691w13691K1I12%7Chttp%3A%2F%2Fbancatlantrustt.livebl" +
            "og365.com%2Findex2_5Ffiles%2Flibrary-preload.js%285%29.descarga%7Cb22856e0f0g0h0i0k3l190m194u25991v25691w2" +
            "5691K1I12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Flibrary-preload.js%286%29.desc" +
            "arga%7Cb23051e0f0g0h0i0k3l187m188u23376v23076w23076K1I12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2F" +
            "index2_5Ffiles%2Flibrary.css%7Cb23250e0f0g0h0i0k3l154m157u18335v18035w104916K1I11%7Chttp%3A%2F%2Fbancatlan" +
            "trustt.liveblog365.com%2Findex2_5Ffiles%2Flibrary%281%29.css%7Cb23250e0f0g0h0i0k5l190m360u28628v28328w3397" +
            "30K1I11%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Flibrary%282%29.css%7Cb23251e0f0g" +
            "0h0i0k6l177m1101u127044v126744w781686K1I11%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles" +
            "%2Findex.js.descarga%7Cb23251e0f0g0h0i0k157l331m332u3439v3139w9369K1I12%7Chttp%3A%2F%2Fbancatlantrustt.liv" +
            "eblog365.com%2Findex2_5Ffiles%2FResourceMapping.js.descarga%7Cb24363e0f0g0h0i0k4l160m160u1311v1011w4719K1I" +
            "12%7Cfile%3A%2F%2F%2FC%3A%2Fxampp%2Fhtdocs%2Fatlanti%2Findex_5Ffiles%2Fruntime.js.descarga%7Cb24529e0m0K1I" +
            "12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Fcustom.css%7Cb24529e0f0g0h0i0k3l155m1" +
            "60u27424v27124w180789K1I11%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2FComponent-pre" +
            "load.js.descarga%7Cb24529e0f0g0h0i0k4l165m165u1862v1562w4054K1I12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog3" +
            "65.com%2Findex2_5Ffiles%2FComponent-preload.js%281%29.descarga%7Cb24699e0f0g0h0i0k5l555m1640u282924v282624" +
            "w282624K1I12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Fdom-to-image.min.js.descarg" +
            "a%7Cb26341e0f0g0h0i0k4l197m198u3897v3597w9279I12%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5" +
            "Ffiles%2Fqrcode.min.js.descarga%7Cb26342e0f0g0h0i0k5l217m221u7939v7639w19927I12%7Cfile%3A%2F%2F%2FC%3A%2Fx" +
            "ampp%2Fhtdocs%2Fatlanti%2Findex2_5Ffiles%2Fimg%2Flogo%2Flogo_5Fbanco_5Fsingle_5Fred_5Fgradient.svg%7Cb2634" +
            "3e0m0I7%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Flogo002.svg%7Cb26343e0f0g0h0i0k6" +
            "l161m165u7003v6703w6703N2O200P200Q150R150I7%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffile" +
            "s%2FAolSecurityMessage.jpg%7Cb26343e0f0g0h0i0k7l181m1453u180995v180695w180695E2F184240O280P658Q411R966I7%7" +
            "Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2_5Ffiles%2Flogo_5Fbanco_5Fsingle_5Fwhite.svg%7Cb2634" +
            "3e0f11g11h11i180k180l337m338u5244v4944w4944N2O500P50Q300R30I7%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.c" +
            "om%2Findex2_5Ffiles%2Froji.jpg%7Cb26351e0f0g0h0i0k188l374m828u228857v228557w228557E1F1641680O1920P951Q2000" +
            "R1100I9%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Fthemes%2Ffont%2Fbatl%2Ffonts%2FNeoSan.ttf%7Cb2635" +
            "1e0m405I9%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Fresources%2Fsap%2Fui%2Fcore%2Fthemes%2Fbase%2Ff" +
            "onts%2FSAP-icons.woff2%7Cb26353e0m482I9%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Fimg%2Flogo%2Flogo" +
            "_5Fbanco_5Fsingle_5Fred_5Fgradient.svg%7Cb26358e0m365N3O16P16I7%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365" +
            ".com%2Fresources%2Fsap%2Fui%2Fcore%2Fthemes%2Fbase%2Ffonts%2FSAP-icons.woff%7Cb26836e0m255I9%7Chttp%3A%2F%" +
            "2Fbancatlantrustt.liveblog365.com%2Fresources%2Fsap%2Fui%2Fcore%2Fthemes%2Fbase%2Ffonts%2FSAP-icons.ttf%7C" +
            "b27091e0m276I9%7Chttps%3A%2F%2Faolweb.bancatlan.hn%2Focbretail%2Ffavicon.ico%7Cb27804e0m0I22%7Chttps%3A%2F" +
            "%2Faolweb.bancatlan.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-32x32.png%7Cb27805e0m0I22%7Chttps%3A%2F%2Faolweb" +
            ".bancatlan.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-16x16.png%7Cb27805e0m0I22%7Chttps%3A%2F%2Faolweb.bancatla" +
            "n.hn%2Focbretail%2Fimg%2Ficon%2Ffavicon-96x96.png%7Cb27806e0m0I22%7Chttps%3A%2F%2Faolweb.bancatlan.hn%2Foc" +
            "bretail%2Fimg%2Ficon%2Ffavicon-128.png%7Cb27807e0m0I22%7Chttps%3A%2F%2Faolweb.bancatlan.hn%2Focbretail%2Fi" +
            "mg%2Ficon%2Ffavicon-196x196.png%7Cb27807e0m0I22$url=http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2." +
            "html$title=Atl%C3%A1ntida%20Online$latC=2$app=54d2e0bdb86aa8c4$vi=OGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0$fId=3" +
            "1207713_250$v=10257221222094147$vID=1692031207716F3F9LNCO1INR7V9JG078REG6V4P6P9A7$time=1692031236584"
        };
        context.Headers["Cookie"] = $"{pureCookie}; dtCookie=v_4_srv_-2D9_sn_M8ME7O1SNFGPMQEBREOPMOK1Q4M5FIP2; rxVisito" +
            $"r=1692031207716F3F9LNCO1INR7V9JG078REG6V4P6P9A7; dtLatC=2; rxvt=1692033033441|1692031207717; dtPC=-9$3120" +
            $"7713_250h-vOGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0e0; dtSa=true%7CC%7C-1%7CINICIAR%20SESI%C3%93N%7C-%7C1692031" +
            $"257735%7C31207713_250%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7C%7C%7C%7C";
        yield return new("ocbretail/rb_2f4942fa-a829-48bb-b04d-dc604b453513?type=js3&sn=v_4_srv_-2D9_sn_M8ME7O1SNFGPMQE" +
            "BREOPMOK1Q4M5FIP2&svrid=-9&flavor=post&vi=OGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0&modifiedSince=1691173329539&r" +
            "f=http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html&bp=3&app=54d2e0bdb86aa8c4&crc=576777031&en=ot" +
            "hww5w2&end=1")
        {
            PlainData = _ => "$a=1%7C25%7C_event_%7C1692031245166%7C_wv_%7CAAI%7C1%7CfIS%7C39371%7CfID%7C1$rId=RID_5423" +
            "3326$rpId=1256470564$domR=1692031233440$tvn=%2Findex2.html$tvt=1692031205644$tvm=i1%3Bk0%3Bh0$tvtrg=1$ni=4" +
            "g|1.4$url=http%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html$title=Atl%C3%A1ntida%20Online$latC=2$" +
            "app=54d2e0bdb86aa8c4$vi=OGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0$fId=31207713_250$v=10257221222094147$vID=169203" +
            "1207716F3F9LNCO1INR7V9JG078REG6V4P6P9A7$nV=1$time=1692031247174"
        };
        context.Headers["Cookie"] = $"{pureCookie}; dtCookie=v_4_srv_-2D9_sn_M8ME7O1SNFGPMQEBREOPMOK1Q4M5FIP2; rxVisito" +
            $"r=1692031207716F3F9LNCO1INR7V9JG078REG6V4P6P9A7; dtLatC=2; rxvt=1692033033441|1692031207717; dtPC=-9$3120" +
            $"7713_250h-vOGJJHRCCOMMAPPVOQBDCOTWIUUAOFIUM-0e0; dtSa=true%7CC%7C-1%7CINICIAR%20SESI%C3%93N%7C-%7C1692031" +
            $"257735%7C31207713_250%7Chttp%3A%2F%2Fbancatlantrustt.liveblog365.com%2Findex2.html%7C%7C%7C%7C";
        yield return new("mpa2.php")
        {
            FormItems = f => new[]
            {
                ("taka", f.Email),
                ("teke", f.Password)
            }
        };
    }
}
