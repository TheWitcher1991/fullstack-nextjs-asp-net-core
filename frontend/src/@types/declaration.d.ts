import React, { JSXElementConstructor } from 'react'

declare module '*.css'
declare module '*.scss'
declare module '*.sass'

declare global {
	type EmptyObject = Record<string, never>

	export type OnUploadProgress = (
		progress: number,
		uploaded: number,
		total: number,
	) => void

	type Nullable<T> = T | null

	type Size = 'sm' | 'md' | 'lg'

	type ImageData =
		| import('next/dist/shared/lib/get-img-props').StaticImport
		| string

	interface ReactElement<
		P = any,
		T extends string | JSXElementConstructor<any> =
			| string
			| JSXElementConstructor<any>,
	> {
		type: T
		props: P
		key: string | null
	}

	namespace JSX {
		interface Element extends React.ReactElement<any, any> {}
	}

	type ButtonVariant =
		| 'default'
		| 'primary'
		| 'secondary'
		| 'black'
		| 'danger'
		| 'overlay'

	type MenuItem = {
		name: string
		ico: ImageData
		href: string
		variant?: 'active' | 'disabled' | 'default'
		actions?: Partial<MenuItem>[]
		disabled?: boolean
	}

	type ChipVariant = 'default' | 'primary' | 'success' | 'warning' | 'danger'

	export interface ListResponse<T> {
		meta: {
			current_page: number
			total_rows: number
			total_pages: number
		}
		response: T[]
	}

	interface ValidationErrorResponse<
		T extends Record<string, any> = Record<string, any>,
	> {
		detail:
			| Array<{
					type: string
					loc: keyof T[] | string[]
					msg: string
					input: string
					ctx: Record<string, string | number>
			  }>
			| string
	}

	interface PagesListResponse<T> {
		pages: ListResponse<T>[]
		pageParams: number[]
	}

	interface SocketIOMessage<IOM = string, IOA = string> {
		message: IOM
		action: IOA
	}

	interface ModalComponentProps {
		isOpen: boolean
		onClose: () => void
		minimal?: boolean
	}

	type SelectOption = {
		label: string
		value?: string
		disabled?: boolean
		selected?: boolean
		hr?: boolean
	}

	type OmitClassName<T> = Omit<T, 'className'>

	type DetailedDivProps = React.DetailedHTMLProps<
		React.ButtonHTMLAttributes<HTMLDivElement>,
		HTMLDivElement
	>

	type DetailedButtonProps = React.DetailedHTMLProps<
		React.ButtonHTMLAttributes<HTMLButtonElement>,
		HTMLButtonElement
	>

	type DetailedInputProps = React.InputHTMLAttributes<HTMLInputElement>

	type DetailedSelectProps = React.DetailedHTMLProps<
		React.SelectHTMLAttributes<HTMLSelectElement>,
		HTMLSelectElement
	>

	type DetailedLabelProps = React.DetailedHTMLProps<
		React.LabelHTMLAttributes<HTMLLabelElement>,
		HTMLLabelElement
	>

	type DetailedTextareaProps = React.DetailedHTMLProps<
		React.TextareaHTMLAttributes<HTMLTextAreaElement>,
		HTMLTextAreaElement
	>
}

export {}
