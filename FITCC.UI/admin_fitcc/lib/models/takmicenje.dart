class Takmicenje {
  List<TakmicenjeItem> takmicenja = [];
}

class TakmicenjeItem {
  late int takmicenjeId;
  late String? naziv;
  late String? slogan;
  late DateTime? pocetak;
  late DateTime? kraj;
  late int? godina;
  late int? brojDana;
  late String? slika;

  TakmicenjeItem(this.takmicenjeId, this.naziv, this.slika, this.pocetak,
      this.kraj, this.godina, this.brojDana, this.slogan);

  factory TakmicenjeItem.fromJson(Map<String, dynamic> map) {
    return TakmicenjeItem(
        map['takmicenjeId'],
        map['naziv'],
        map['slika'],
        map['pocetak'],
        map['kraj'],
        map['godina'],
        map['brojDana'],
        map['slogan']);
  }
}
