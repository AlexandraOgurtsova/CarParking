   M S B A M L   `   `   `  ����K  Gкурсовой, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:курсовойкурсовой  5   	   #    курсовой.registration   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=3.1.2.1465, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   *localclr-namespace:курсовой  5   	   -   5          � 
ResizeMode$  NoResize=�5	   	    � WindowStyle$
 None=�6   
������� � WindowStartupLocation$ CenterScreen=�6F   
���   �$	��0.5q�6    � Title$ Window1��5
   	   $��405.333��6   $��365.334��6*   .��5      � $��0,0,0.333,0.333q�6   .+�5   
   �� -   5         ��Name$ login��5   �   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Логин��6   
�������$��Champagne & Limousines)�6K   $��16(�6s   $
��Left=�6�   $��27��6�   $��
53,104,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��248��6�   �� 5   
   -   5        $ 	firstName��5      $ Имя��6   
�������$��Champagne & Limousines)�6I   $��16(�6q   $
��Left=�6�   $��26��6�   $��
53,144,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��248��6�   �� 5   
   -   5        $ 
secondName��5   �   $ Фамилия��6   
�������$��Champagne & Limousines)�6M   $��16(�6u   $
��Left=�6�   $��27��6�   $��
53,184,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��248��6�   �� 5   
   -   5        $ Mobile��5   �   $ Телефон��6   
�������$��Champagne & Limousines)�6M   $��16(�6u   $
��Left=�6�   $��28��6�   $��
53,224,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��248��6�   �� 5   
   -   5         ��Name$ buttonRegistration��5   '   ���#ff4040$��Регистрация��6C   
�������$
��Left=�6�   $��
53,331,0,0q�6�   $	��Top=�6�   $	��247��6�   $��35��6�    J� RenderTransformOrigin$ 0.5,0.5&�6  ��6l   Z� 6  G� 5   
   -   5        	 G�Name$	 password��5   �   $ Пароль��6   
�������$��Champagne & Limousines)�6P   $��16(�6x   $
��Left=�6�   $��53,295,0,77.667q�6�   $	��248��6�   �� 5   
   
�������$��Champagne & Limousines)�6#   $��РЕГИСТРАЦИЯ��6L   $
��Left=�6b   $��
103,57,0,0q�6}   $	��Top=�6�   $��20(�6�   �� 5   
   -   5        $
 Mail��5   �   $ 
Почта��6   
�������$��Champagne & Limousines)�6K   $��16(�6s   $
��Left=�6�   $��27��6�   $��
53,263,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��248��6�   � 5   
   ���#ff4040$
��Left=�6$   $��42��6?   $	��Top=�6K   $	��365��6c   .+�5      �� $
��Left=�6   $��42��64   $	��Top=�6@   $	��365��6X   .+�5      �� -	   5        $ Minimize��5      $��Right=�6+   $��72��6G   $��35��6R   
�������$��0,1,43.333,1.333q�6�   ��6^   Z� ��6t   Z� .��5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$
 WindowMinimize=�6.   $��25��6E   $��20��6Q   5      5      5      �� 5   
   -
   5        $ Close��5      $��Right=�6    
�������$��	0,2,0,371q�6�   $��63��6�   ��6<   Z� ��6R   Z� .��5        $
 windowclose=�6&   $��25��6:   $��36��6F   5      �� 5   
   -   5        $ aotorization��5   S   ���#ff4040$��Авторизация��6i   $
��Left=�6   $��115,366,0,0q�6�   $	��Top=�6�   $	��131��6�   ��6&   Z� ��6<   Z� 6�   5#      5$      