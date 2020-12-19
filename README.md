# Simple-Bag-System（简单背包系统）
Simple Bag System
通过使用ScriptableObject实现数据和UI显示的分离

## UIManager.cs
对背包UI进行管理
存储信息主要有:
*背包UI的GameObject
*背包格子的容器（确定生成格子的父级）
*背包格子的预制体（Prefab）
*存放生成背包格子的链表（List）

## Player
Player控制脚本中存储背包的数据（BagScriptableObject）,需要数据时，可以进行数据的传递

## BagScriptableObject.cs
存放ItemScriptableObject的链表

## ItemScriptableObject.cs
存放生成Item Slot的必要信息
* Item Name
* Item Image
* Item Count
* Item Info

## Slot.cs
挂载在Slot Prefabs上，在生成相应格子时进行对应的初始化工作。
存储信息包括：
* 当前格子的所需背包（BagScriptableObject）
* 当前格子上道具信息（ItemScriptableObject）（可以为null）
* Item Image 和 Item Count(Text) 控制其下组件的显隐

##Item.cs
挂载在所有在世界上生成的物体上
包含信息：
* 所属道具的数据信息（ItemScriptableObject）
* canEquip(bool)
* canUse(bool)
该脚本可以通过继承实现多态，已达到一般向特殊的转化

## ItemOnDrag.cs
实现背包物体的拖拽功能
需要实现IBeginDragHandle、IDragHandle和IEndDragHandle接口

## BagOnDrag.cs
实现背包的拖拽功能
需要实现IDragHandle接口
