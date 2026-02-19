Mishnat Yosef - Community Sales Management System
מערכת לניהול מכירות קהילתיות המבוססת על המודל של "משנת יוסף". המערכת מאפשרת ניהול מלא של מלאי, לקוחות, הזמנות ונקודות חלוקה, תוך שימוש בארכיטקטורה מודרנית והפרדה ברורה בין הלוגיקה העסקית לתצוגה.

🛠 טכנולוגיות וכלים
Core: .NET Framework 4.7.2, C#

UI Framework: WPF (Windows Presentation Foundation)

Database & ORM: SQL Server (MDF file), Entity Framework 6 (Database First)

Architecture: N-Tier Architecture (GUI, BLL, DAL/Model)

📁 מבנה הפרויקט והפרדת שכבות
הפרויקט בנוי בצורה מודולרית כדי לאפשר תחזוקה קלה ובדיקות נוחות:

1. MishnatYosef.Model (שכבת הנתונים)
שכבה זו מנהלת את הקשר מול מסד הנתונים באמצעות Entity Framework.

Model1.edmx: מיפוי טבלאות מסד הנתונים לאובייקטים ב-C#.

Entities: מחלקות המייצגות את הישויות במערכת: Client, Product, Sale, Booking, Branch, Category ועוד.

2. MishnatYosef.BLL (Business Logic Layer)
כאן נמצאת ה"חוכמה" של המערכת. השכבה כוללת:

Services: מחלקות שירות (כמו ProductService, ClientServise, BookingService) המבצעות פעולות CRUD (יצירה, קריאה, עדכון ומחיקה) מול מסד הנתונים.

Validation Rules: מחלקות אימות נתונים מותאמות אישית (כגון IsId לבדיקת תקינות ת"ז, AgeRangeRule ו-isHebrewRule) המבטיחות שלמות נתונים לפני שמירתם.

Globaly: מחלקה סטטית לניהול הקשר למסד הנתונים (DbContext) ושמירת מצב המשתמש המחובר.

MyPicture: לוגיקה לניהול והצגת תמונות מוצרים במערכת.

3. MishnatYosef.GUI (Presentation Layer)
ממשק משתמש עשיר המבוסס על XAML ו-Styles:

דפי ניהול (Admin): הוספת מכירות חדשות (AddSale), הוספת מותגים (AddTrand) וצפייה בנתונים.

דפי לקוח (Client): צפייה בהיסטוריית הזמנות (BookingCPage), ביצוע הזמנות ועדכון פרטים אישיים.

Dashboard: דף נחיתה אינפורמטיבי המציג סטטיסטיקות בזמן אמת (כמות לקוחות, מוצרים וסניפים).

✨ פיצ'רים בולטים בקוד
Custom Validation: שימוש ב-ValidationRule של WPF כדי לתת פידבק מיידי למשתמש על קלט לא תקין בתוך ה-XAML.

Data Binding: קישור נתונים מלא בין ה-UI למודלים, מה שמאפשר עדכון אוטומטי של התצוגה.

LINQ: שימוש נרחב בשאילתות LINQ לסינון ושליפת נתונים מורכבים (למשל: שליפת ההזמנה האחרונה של לקוח ספציפי).

Resource Dictionaries: שימוש במילוני משאבים (Styles) לשמירה על עיצוב אחיד ומרשים לכל אורך האפליקציה.
