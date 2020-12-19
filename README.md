# Simple-Bag-System（简单背包系统）
Simple Bag System<br>
通过使用ScriptableObject实现数据和UI显示的分离<br>

## UIManager.cs
对背包UI进行管理<br>
存储信息主要有:<br>
* 背包UI的GameObject
* 背包格子的容器（确定生成格子的父级）
* 背包格子的预制体（Prefab）
* 存放生成背包格子的链表（List）

## Player
Player控制脚本中存储背包的数据（BagScriptableObject）,需要数据时，可以进行数据的传递<br>

## BagScriptableObject.cs
存放ItemScriptableObject的链表<br>

## ItemScriptableObject.cs
存放生成Item Slot的必要信息<br>
* Item Name
* Item Image
* Item Count
* Item Info

## Slot.cs
挂载在Slot Prefabs上，在生成相应格子时进行对应的初始化工作。<br>
存储信息包括：<br>
* 当前格子的所需背包（BagScriptableObject）
* 当前格子上道具信息（ItemScriptableObject）（可以为null）
* Item Image 和 Item Count(Text) 控制其下组件的显隐

## Item.cs
挂载在所有在世界上生成的物体上<br>
包含信息：<br>
* 所属道具的数据信息（ItemScriptableObject）
* canEquip(bool)
* canUse(bool)
该脚本可以通过继承实现多态，已达到一般向特殊的转化<br>

## ItemOnDrag.cs
实现背包物体的拖拽功能<br>
需要实现IBeginDragHandle、IDragHandle和IEndDragHandle接口<br>

## BagOnDrag.cs
实现背包的拖拽功能<br>
需要实现IDragHandle接口<br>

## 存储功能
目前存在bug，由于JsonUtility只能进行简单的json化，不能将复杂的嵌套进行完全json化，导致物品的数量等信息无法保存下来。
