   M S B A M L   `   `   `  ����K  Gкурсовой, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:курсовойкурсовой  5   	   &     курсовой.history_parking   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:курсовой     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          � 
ResizeMode$  NoResize=�5
   	    � WindowStyle$
 None=�6   
������� � WindowStartupLocation$ CenterScreen=�6F   
���   �$	��0.5q�5       � Title$ Window2��5   	   $	��441��6   $	��824��6&   .��5      � $��0,43,-1.333,-0.333q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid��5   <      
IsReadOnly .    CanUserAddRows .  $
��Left=�6N   $	��236��6i   $��
80,119,0,0q�6v   $	��Top=�6�   $	��642��6�      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Номер��6D   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
id_history+6S     5      $	 Операция��6C   $	
 300 6U    6%   �� *	operation+6U     5      $	 Дата��6>   $	
 190 6L    6%   �� *date+6L   5      � 5   
   ���#ff4040$
��Left=�6$   $��43��6?   $��	0,-43,0,0q�6K   $	��Top=�6^   $	��823��6v   .+�5      �� $
��Left=�6   $��42��64   $	��Top=�6@   $	��822��6X   .+�5      �� -   5         ��Name$ Minimize��5      $��Right=�6+   $��54��6G   $��35��6R   
�������$��0,1,45.333,1.333q�6�   ��6^   Z� ��6t   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�6.   $��25��6E   $��20��6Q   5      �� 5      -   5        $ Close��5      $��Right=�6(   
�������$��0,-34,0,370q�6�   $��56��6�   ��6D   Z� ��6Z   Z� .��5        $ windowclose=�6.   $��25��6B   $��21��6N   5      5      5!      o� 5"   
   $
��Left=�6   $��24��6*   $	��Top=�66   $	��822��6N   .@�5#      m� -   5         m�Name$
 home��5#      $��Главная��6&   $��26��6J   $
��Left=�6V   m� 5$      -   5        $ controlUsers��5$      $��Пользователи��6/   $��26��6`   $
��Left=�6l   m� 5%      -   5        $ controlCars��5%      $��Машины��6.   $
��Left=�6X    J� RenderTransformOrigin$ 0.517,0.292&�6s   $��26��6�   m� 5&      -   5        $ history��5&   9    J� Opacity$ 50Q�6   ���#ff4040$��Отчетность��6J   $��right=�6^   $��26��6z   5'      �� 5(   
   -	   5        $ clean��5(   &   ���#ff4040$��Очистить��65   $
��Left=�6H   $��	80,63,0,0q�6c   $	��Top=�6v   $	��126��6�   6�   5.      5/      