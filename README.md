# Game From Comments

A small Unity game inspired by YouTube comments. 
Each YouTube shorts is about implementing feature into the game - then I ask for a new one in the comments.

<img width="1085" height="566" alt="image" src="https://github.com/user-attachments/assets/d7aa1b49-71cd-478f-b05a-46baad9cb9d5" />


## Features
- 2D Platformer
- Size-changing Player
- Shooting with Joystick
- Level are built with Tilemap
- Using Zenject for DI
- using DoTween for animations
- using UniTask for async

## CODE
1. PascalCase for public members
        `public int NumberOfAttacks`
2. CamelCase with prefix `_` for private members
        `private int _numberOfAttacks`
        `[SerializeField] private int _numberOfAttacks`
3. Mix of UpperCase and SnakeCase for const members
        `private const int NUMBER_OF_ATTACKS`
        `public const int NUMBER_OF_ATTACKS`
4. Always include access modifier
5. Functions are verbs, classes/structs are nouns
6. Boolean should always be in a form of question (usually adding `is` at the beginning of it's name is enough)(editor tools are exceptions for this)
7. Interface name starts with `I` (e.g. `IInteractable`)
8. `if` without curly brackets is allowed only for one liners
e.g.:  
        `if(true)`  
            `return null`  
Exception is guard clause:  
        `if (true) return null`  
9. Methods used for events subscription are always private and starts with `On_` (e.g. `private void On_InputMapChange() { }`)  
10. TODO format:  
        `//TODO: something that needs to be done (optional: URL to task)`
11. Code hierarchy
    **Keywords that are not mentioned below (like `async`, `static`, `abstract`, etc.) does not affect the order**
    * Members (properties -> public -> public const -> private sfield -> private -> private const):
        `public int NumberOfAttacks { get; set; }`  
        `public int NumberOfAttacks`  
        `public const int NUMBER_OF_ATTACKS`  
        `[SerializeField] private int _numberOfAttacks`  
        `private int _numberOfAttacks`  
        `private const int _numberOfAttacks`  
    * Methods (mono/ctor -> public -> private -> debug code/methods used for events subscription):  
        `private void Start() { }` - MonoBehaviour methods (Start, Update, Awake, OnTriggerEnter, OnEnable, etc.) are always above the rest  
        `Constructor`  
        `public void Initialize() { }`  
        `private void Initialize() { }`  
        `private void On_InputMapChange() { }`  
        `private void OnDrawGizmos() { }`  
12. Any editor code should be inside `#if`  

## REPO CONVENTIONS
1. Branch name starts with
    * `feature` if it contains new feature (including adding/removing new packages, assets etc.)  
            `feature/some-feature-to-do`
    * `bugfix` if it contains bugfixes that are supposed to be reviewd  
            `bugfix/bug-to-fix`
    * `hotfix` if it contains fix for major bug that needs to be merged asap  
            `hotfix/important-bug-to-fix`
2. Branch should be responsible only for the thing it describes (usually the equivalent of one task)
3. Commit name should be short and concise
4. Anything else that needs to be mentioned should be in commit description
