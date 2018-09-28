# Hash Table

## Hash Fonksiyonu nedir?

İnput olarak aldığı değeri matematiksel bir denkleme sokarak başka bir değere dönüştüren fonksiyondur. Çok büyük girdi uzayına karşı kısıtlı bir çıktı uzayı vardır. Her ne kadar iki uzay da yeterince büyük olsa da en nihayetinde girdi uzayı daha büyük olduğu için en az iki girdinin aynı çıktıyı vermesi gerekir. Yani –lise matematik bilgisi ile açıklayacak olursak- fonksiyon birebirdir ama örten değildir. Bu olayın handikapıdır ama şu an kriptoda kullanılan hash fonksiyonları için iki farklı girdinin aynı çıktıyı verdiği gözlenmemiştir. Bu gözlendiğinde zaten o hash fonksiyonunun devri biter. Şu an tüm haberleşmemizi bu fonksiyonlar yeterince güvenilir olduğu için yapabiliyoruz. Bu özel fonksiyonların tersi alınamadığı (ya da çok zor olduğu) için bir şeyin hashini almak onu asla geri döndüremeyeceğimiz başka bir forma döndürmek oluyor.

## Peki bunun konumuzla ne alakası var?

Şöyle ki; very yapılarından biri de &quot;map&quot; yani eşleşme yöntemidir. Key-Value (anahtar-değer) eşleşmesi denir. Diyelim ki ben öğrencileri bir listed tutmak istiyorum vedışarıdan sadece numarası bilinsin, bana sorgulandıında ben ismini söyleyeyim istiyorum. Bu durumda numarası &quot;key&quot;, ismi ie &quot;value&quot; olur. Ben tabloya (map&#39;e) kaydederken key-value ikilisi ile kaydederim ama dışarıdan sadece key ile erişim sağlatırım.

_Buraya kadar hash ile ilgili bir şey yok._

Şimdi düşünelim. Biz bunu nasıl tutabilriz? Mesela aynı very tipinde olsalar iki boyutlu array ile birinci eleman key ikinci eleman value olacak şekilde yapabiliriz. Ya da iki tane farklı array tutarız. Biri key array olur biri value array olur. Key verildiğinde keyArray içinde indexini alıp aynı index&#39;I valueArray içinde döndürebiliriz. Ya da binary three yaparız iki tane orda aynı işlemleri yapabiliriz. Bunlar da mapping işlemini yerine getirir baktığınız zaman. Fakat bunlarda sıkıntı sürekli O(n) veya O(logn) karmaşıklıklı arama işlemine tabi tutulma problemidir. Yani ben öncelikle key&#39;in hangi indexte olacağını bulmalıyım ki ordan value&#39;ya ulaşayım. Peki nasıl iyileştirebiliriz?

### Çare Hash Table

Düşünmüşler ki:

Biz bi array alanı alalım. Value&#39;ları bu Alana ekleyip çıkaralım. Value&#39;ları nereye koyacağımızı da key değerleri belirlesin. Sorgularken de böylece, key değerlerinden nerede olduğuna erişebiliriz. Şimdiii biz bu key-value ikilisindeki key değerlerinin (tek key var gibi düşünyoruz her value için) Hash&#39;ini alsak bize bir değer çıkacak ve bunu adres olarak kullanmak çok mantıklı. Bunu ilk aldığımız array içerisinde tutmak için de arraysize a göre mdounu alırız. Hoop istediğimiz bölgede bir adres çıkar karşımıza. Value&#39;yu oraya yerleştiririz. Aratırken de artık key hangi indexteymiş diye büyün array/tree yi taramayız da yine hash fonksiyonuna sokar, sonuca bakar gider o adresten O(1) karmaşıklığı ile alırız.

Problemler:

Efenim tamam da nasıl güvenicez, iki farklı key sonuçta aynı hash değeri çıakrtabilir dedik? Evet, doğru. Eğer array küçkse özellikle, bunun olması mümkündür. Bu nedenle aynı hash&#39;e denk gelenleri de ayrıca linked list ile bağlama yöntemi vardır.


Şekil 1 ref[wikipedia]

Bunda da array elemanları sadece value değil, linked list node&#39;una tekabul eder ki bu node içinde \&lt;key,value\&gt; ikilisini barındırır. Yeni o adres için ilk \&lt;key,value\&gt; ikilisi eklendikten sonra gelen value&#39;nun key&#39;&#39; de aynı hash sonucunu verdiğinde bir öncekinin sonuna eklenir. Böylece arama esnasında adres yine O(1) de bulunur ama o node&#39;da kaç tane ikili varsa ona göre arama devam eder O(m) karmaşıklığına çıkar. Yani Karmaşıklık az da olsa artar. En kötü durumda (ki çook zor ihtimal) tüm value&#39;ların key&#39;leri aynı hash&#39;I verir ve karmaşıklık yine O(n) olur. Ama bu çok zor bir ihtimaldir. Bu arada Hash adreslemsinden sonar yerleştirmede balanced tree de istenirse kullanılabilir.

## Ne oldu şimdi?

Biz tüm value&#39;ları bir array&#39;e koysaydık key&#39;leri node&#39;larda tutmamız gerekmezdi ekstra yer kaplamış olduk.

Ama _arama_ hızımızı inanılmaz arttırdık. Bu onur hepimizin 