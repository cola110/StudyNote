<?php

    class ValidateCode
	{
		private $charset = 'abcdefghkmnprstuvwxyzABCDEFGHKMNPRSTUVWXYZ23456789';
		private $code;
		private $codelen =4;
		private $width = 130;
		private $height = 50;
		private $img;
		private $font;
		private $fontsize = 20;
		private $fontcolor;
		
		public function __construct()
		{
			$this -> font = dirname(__FILE__).'/font/elephant.ttf';
		}

 
		
	}
?>