   M S B A M L   `   `   `  ����K  Gкурсовой, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:курсовойкурсовой  5   	   )    #курсовой.machine_accounting   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:курсовой     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � WindowStyle$
 None=�6   
������� � WindowStartupLocation$ CenterScreen=�6F   
���   �$	��0.5q�5       � Title$ machine_accounting��5   	   $	��441��6$   $	��824��61   .��5      � $��0,41,0,10.333q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5   \      
IsReadOnly .    CanUserAddRows .  $
��Left=�6n   $	��229��6�   $��
47,125,0,0q�6�   $	��Top=�6�   $	��731��6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Номер��6@   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Number+6O     5      $	 Владелец��6?   $	
 100 6Q    6%   �� *Owner+6Q     5      $	 
Марка��6>   $	
 100 6M    6%   �� *Mark+6M     5      $	 Тип��6>   $	
 100 6K    6%   �� *Type+6K     5      $	 Цвет��6@   $	
 100 6N    6%   �� *Colour+6N   5      � 5   
   ���#ff4040$
��Left=�6$   $��41��6?   $��0,-41,-1.333,0q�6K   $	��Top=�6c   $	��824��6{   .+�5      �� $
��Left=�6   $��42��64   $	��Top=�6@   $	��824��6X   .+�5      �� -   5         ��Name$ Minimize��5      $��Right=�6+   $��72��6G   $��35��6R   
�������$��0,1,44,1.333q�6�   ��6^   Z� ��6t   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6.   $��25��6E   $��20��6Q   5      �� 5      -   5        $ Close��5      $��Right=�6(   
�������$��0,-34,0,370q�6�   $��68��6�   ��6D   Z� ��6Z   Z� .��5        $ windowclose=�6.   $��25��6B   $��36��6N   5      5       5!      o� 5"   
   $
��Left=�6   $��26��6*   $	��Top=�66   $	��824��6N   .@�5#      m� -   5         m�Name$
 home��5#      $��Главная��6&   $��26��6J   $
��Left=�6V   m� 5$      -   5        $ controlUsers��5$      $��Пользователи��6/   $��26��6`   $
��Left=�6l   m� 5%      -   5        $ controlCars��5%   :    J� Opacity$ 50Q�6   ���#ff4040$��Машины��6O   $
��Left=�6`    J� RenderTransformOrigin$ 0.517,0.292&�6{   $��26��6�   m� 5&      -   5        $ history��5&      $��Отчетность��6(   $��right=�6<   $��26��6X   6d   5(      �� 5)   
   -	   5        $ delete��5)      ���#ff4040$��Удалить��67   $
��Left=�6I   $��	47,70,0,0q�6d   $	��Top=�6w   $	��100��6�   6�   5,      5-      