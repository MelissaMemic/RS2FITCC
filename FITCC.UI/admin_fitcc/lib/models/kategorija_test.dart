class KategorijaTest {
  int kategorijaId;
  String naziv;
  String opis;
  int takmicenjeId;
  List<dynamic> kriterijs; // You may need to replace dynamic with the actual type of kriterijs
  List<dynamic> projekats; // You may need to replace dynamic with the actual type of projekats

  KategorijaTest({
    required this.kategorijaId,
    required this.naziv,
    required this.opis,
    required this.takmicenjeId,
    required this.kriterijs,
    required this.projekats,
  });

  factory KategorijaTest.fromJson(Map<String, dynamic> json) {
    return KategorijaTest(
      kategorijaId: json['kategorijaId'],
      naziv: json['naziv'],
      opis: json['opis'],
      takmicenjeId: json['takmicenjeId'],
      kriterijs: json['kriterijs'] ?? [], // Replace dynamic with the actual type if known
      projekats: json['projekats'] ?? [], // Replace dynamic with the actual type if known
    );
  }
}
