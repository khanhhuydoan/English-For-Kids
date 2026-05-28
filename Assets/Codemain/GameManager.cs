using UnityEngine;

public static class GameManager
{
    // Biến lưu trữ chủ đề hiện tại
    public static string chuDeHienTai = "Animal";

    // Danh sách 12 từ vựng cho từng chủ đề 
    // (Hãy đảm bảo tên các từ này KHỚP Y HỆT với tên file ảnh và file âm thanh của bạn)
    public static string[] tuVungAlphabet = {
        "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
        "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
    };
    public static string[] tuVungAnimal = { "Cat", "Dog", "Lion", "Tiger", "Elephant", "Wolf", "Fish", "Rabbit", "Pig", "Cow", "Sheep", "Horse" };
    public static string[] tuVungFood = { "Burger", "Pizza", "Donut", "Ice Cream", "Hotdog", "Cake", "Bread", "Egg", "Meat", "Rice", "Soup", "Milk" };
    public static string[] tuVungFruit = { "Apple", "Banana", "Orange", "Grape", "Mango", "Pear", "Peach", "Plum", "Kiwi", "Melon", "Lemon", "Cherry" };
    public static string[] tuVungVehicle = { "Car", "Bus", "Train", "Plane", "Ship", "Bike", "Boat", "Taxi", "Truck", "Subway", "Helicopter", "Rocket" };
    public static string[] tuVungJob = { "Doctor", "Teacher", "Police", "Farmer", "Chef", "Nurse", "Pilot", "Singer", "Actor", "Artist", "Judge", "Driver" };
}