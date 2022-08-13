Hash.Hash hash = new(7);

hash.InsertElement(3, 3);
hash.InsertElement("a", 1);
hash.InsertElement("b", 2);
hash.InsertElement("c", 3);
hash.InsertElement("d", 4);
hash.InsertElement("e", 5);
hash.InsertElement("f", 6);
hash.RemoveItem("e");

hash.Show();
//(d: 4) Null (a: 1) (3: 3) (f: 6) (c: 3) (b: 2)

hash.InsertElement("g", 7);
hash.Show();
//(d: 4) (g: 7) (a: 1) (3: 3) (f: 6) (c: 3) (b: 2)

hash.InsertElement("l", 8);
hash.Show();
//(d: 4) (g: 7) (a: 1) (3: 3) (f: 6) (c: 3) (b: 2) (l: 8) Null Null Null Null Null Null