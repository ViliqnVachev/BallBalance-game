# BallBalance-game Viliyan Vachev
Simple game ball balance. Technology Unity and C#

Курсова работа по Системи за виртуална реалност
Изготвил: Вилиян Вачев


Специалност: Компютърни технологии и приложно програмиране(задочно обучение за магистри)








Технически университет                              Дата: 24.06.2020 г.
гр. София





1.	Въведение
Чрез използването на програмата Unity бе създадена 3D  игра с цел развлечение. Създаденият проект съдържа множество обекти под формата на кубове, сфери, конуси и камери в триизмерна среда. Играта е от типа на „Ball balance“. При стартирането, играчът може да управлява сфера, която е главният обект в програмата. Целта е, преминавайки през препятствията на терена да се достигне до финалната линия. В случай на неуспех или докосване на основната платформа съответното ниво се рестартира. След успешното достигане до финала играчът бива препращан към следващото ниво. За целта на проекта, нивата в приложението са 2, с възможност за разширяване в бъдеще. 

2.	Реализация
Използваните технологии за реализация на проекта са Unity и C#.
-	Създаване на първо ниво
Създаване на основния терен: Основният терен се състои от куб, който е преоразмерен. Той служи за рестартиране на нивото при докосването му от играча. За тези цел е необходимо създаването на C# скрипт. Скриптът съдържа следните методи

public class RestartLevelOnCollision : MonoBehaviour
{

    [SerializeField]
    string strTag;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag==strTag)
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

Чрез стринга „strTag“ задаваме тага на обекта, който при докосване на основния терен да рестартира сцената.
Също така е добавен и допълнителен скрипт за рестарт на сцената при натискане на клавиша „R“ от потребителя. Целта на този скрипт е при евентуално забиване на играта, потребителят да може сам да рестартира нивото. За целта е създаден празен GameObject, към който е добавен следният скрипт
public class RestartLevel : MonoBehaviour
{
    [SerializeField]
    KeyCode keyRestart;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(keyRestart))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

Създаване на сфера: Сферата представлява играчът. За да може потребителят да управлява сферата по координатите x и z е необходимо създаването на скрипт. Скриптът съдържа променливи, които при натискането на конкретен клавиш от клавиатурата променят радиуса по координатната система. Скриптът е добавен като компонент към сферата два пъти, заради нуждата от корекция по двете оси (x и z)
public class PlayerControledVelocity : MonoBehaviour
{
    [SerializeField]
    Vector3 v3Force;

    [SerializeField]
    KeyCode keyPositive;

    [SerializeField]
    KeyCode keyNegative;

    void FixedUpdate()
    {
        if (Input.GetKey(keyPositive))
        {
            GetComponent<Rigidbody>().velocity += v3Force;
        }

        if (Input.GetKey(keyNegative))
        {
            GetComponent<Rigidbody>().velocity -= v3Force;
        }

    }
}

Създаване на камера, която да следи позицията на сферата: Създаването на такъв обект е нобходимо поради добавеното движение на сферата по-горе. За целта е създаден празен GameObject, в който е сложен Main camera обекта. След това е създаден скрипт, който копира позицията на сферата. По този начин камерата следи изцяло позицията на сферата. Скриптът се състои от 
public class CopyPosition : MonoBehaviour
{
    [SerializeField]
    Transform transTarget;

   
    void Update()
    {
        transform.position = transTarget.position;
    }
}

Създаване на препятствия: За създаването на препятствията в играта основно са използвани кубове, които са преоразмерени.

Създаване на финиш линия и смяна на сцената (смяна към следващо ниво): За създаване на финиш лентата е създаден куб, който е преоразмерен. На този обект е добавен компонент rigidBody. Благодарение на този компонент става и смяната между нивата. За създаването на следващото ниво е създадена нова сцена ( копирана е главната сцена, след което част от препятствията са променени като сложността за преминване е по-голяма). Самата смяна между нивата става чрез създаването на скрипт, който е закачен към финиш лентата. Скриптът съдържа метод, който при докосване на сферата с финиша се зарежда новосъздадената по-горе сцена. 
public class NextLevel : MonoBehaviour
{
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "player")
        {
            Debug.Log("detected");
            SceneManager.LoadScene("Nextlevel");
            
        }
    }
}

Други използвани компоненти: Създадена е папка с материали, която съдържа цветовете, използвани за различните обекти в нивата.

-	Билдване на играта: За билдването на играта 2-те сцени трябва да бъдат запазени. От file-> build settings са добавени 2-те сцени, след което проектът е билднат.

3.	Използвана информация
-	ТУ- лекции и упражнения по СВР.
-	https://www.youtube.com
-	https://docs.unity3d.com/Manual/index.html
-	https://stackoverflow.com/

