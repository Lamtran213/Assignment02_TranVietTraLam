   M S B A M L   `   `   `  ����K  GAssignment02_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Assignment02_WPFAssignment02_WPF  5   	   *    $Assignment02_WPF.CandidateManagement   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Assignment02_WPF     5   	     � Title$  CandidateManagement��5   	   $	��700��6%   $	��800��62    � 
ResizeMode$ NoResize=�6>   .��5	      � .+�5
   
   �� $��CANDIDATE MANAGEMENT��6   $��Center=�6/   $��0,50,0,0q�6L   $	��Top=�6^    J� RenderTransformOrigin$ 0.665,-0.068&�6v   $��Comic Sans MS)�6�   $��22(�6�   �� 5   
   $
��Left=�6   $��
97,107,0,0q�6/   $
��Wrap=�6C   $��Candidate ID ��6W   $	��Top=�6l   $��Comic Sans MS)�6�   �� 5   
   -   5         ��Name$ txtCandidateID��5      $
��Left=�6*   $��203,106,0,0q�6E    �� TextWrapping$
 Wrap=�6Z   $	��Top=�6n   $	��120��6�   $��Comic Sans MS)�6�   �� 5   
   $
��Left=�6   $��
97,160,0,0q�6/   $
��Wrap=�6C   $��Fullname��6W   $	��Top=�6g   $��Comic Sans MS)�6   �� 5   
   -   5        $ txtFullName��5      $
��Left=�6'   $��203,159,0,0q�6B   $
 Wrap=�6W   $	��Top=�6k   $	��120��6�   $��Comic Sans MS)�6�   �� 5   
   $
��Left=�6   $��
97,217,0,0q�6/   $
��Wrap=�6C   $��	Birthdate��6W   $	��Top=�6h   $��Comic Sans MS)�6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ dpBirthdate��5      $
��Left=�6*   $��203,213,0,0q�6E   $	��Top=�6Z   $	��120��6r   $��Comic Sans MS)�6~   �� 5   
   $
��Left=�6   $��501,107,0,0q�6/   $
��Wrap=�6D   $��
Posting ID��6X   $	��Top=�6j   $��Comic Sans MS)�6�   �� 5   
   $
��Left=�6   $��501,160,0,0q�6/   $
��Wrap=�6D   $��Profile URL��6X   $	��Top=�6k   $��Comic Sans MS)�6�   �� 5   
   -   5        $ txtProfileURL��5      $
��Left=�6)   $��606,159,0,0q�6D   $
 Wrap=�6Y   $	��Top=�6m   $	��120��6�   $��Comic Sans MS)�6�   �� 5   
   $
��Left=�6   $��499,217,0,0q�6/   $
��Wrap=�6D   $��Description��6X   $	��Top=�6k   $��Comic Sans MS)�6�   �� 5   
   -   5        $ txtDescription��5      $
��Left=�6*   $��606,219,0,0q�6E   $
 Wrap=�6Z   $	��Top=�6n   $	��153��6�   $��71��6�   $��Comic Sans MS)�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dtgCandidateProfile��5      $��0,324,0,195q�6[   $��Comic Sans MS)�6�   �� 5   
   -   5         ��Name$ btnAdd��5      $	��Add��6!   $
��Left=�6/   $��
82,581,0,0q�6J   $	��Top=�6^   $��Comic Sans MS)�6�   �� 5   
   -   5        $ 	btnDelete��5      $��Delete��6$   $
��Left=�65   $��244,581,0,0q�6P   $	��Top=�6e   $��Comic Sans MS)�6�   �� 5   
   -	   5        $ 	btnUpdate��5      $��Update��6$   $
��Left=�65   $��436,581,0,0q�6P   $	��Top=�6e   $��Comic Sans MS)�6�   �� 5   
   -
   5        $ btnClose��5      $��Close��6#   $
��Left=�63   $��626,581,0,0q�6N   $	��Top=�6c   $��Comic Sans MS)�6�   �� 5   
   -   5         ��Name$ cbxPostingID��5      $
��Left=�6)   $��606,104,0,0q�6D   $	��Top=�6Y   $	��120��6q   $��Comic Sans MS)�6}   �� 5   
   -   5        $ btnJobPosting��5      $��Job posting��6(   $
��Left=�6>   $��	40,50,0,0q�6Y   $	��Top=�6l   $��Comic Sans MS)�6�   5      5      