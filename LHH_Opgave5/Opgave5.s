	.file	"Opgave5.c"
	.text
	.def	___main;	.scl	2;	.type	32;	.endef
	.section .rdata,"dr"
LC0:
	.ascii "\12Enter two integers: \0"
LC1:
	.ascii "%d %d\0"
LC2:
	.ascii "%d + %d = %d\12\0"
	.section	.text.startup,"x"
	.p2align 4
	.globl	_main
	.def	_main;	.scl	2;	.type	32;	.endef
_main:
LFB15:
	.cfi_startproc
	pushl	%ebp
	.cfi_def_cfa_offset 8
	.cfi_offset 5, -8
	movl	%esp, %ebp
	.cfi_def_cfa_register 5
	andl	$-16, %esp
	subl	$32, %esp
	call	___main
	movl	$LC0, (%esp)
	call	_printf
	leal	28(%esp), %eax
	movl	$LC1, (%esp)
	movl	%eax, 8(%esp)
	leal	24(%esp), %eax
	movl	%eax, 4(%esp)
	call	_scanf
	movl	24(%esp), %eax
	movl	28(%esp), %edx
	movl	$LC2, (%esp)
	leal	(%eax,%edx), %ecx
	movl	%edx, 8(%esp)
	movl	%ecx, 12(%esp)
	movl	%eax, 4(%esp)
	call	_printf
	leave
	.cfi_restore 5
	.cfi_def_cfa 4, 4
	ret
	.cfi_endproc
LFE15:
	.ident	"GCC: (MinGW.org GCC Build-2) 9.2.0"
	.def	_printf;	.scl	2;	.type	32;	.endef
	.def	_scanf;	.scl	2;	.type	32;	.endef
