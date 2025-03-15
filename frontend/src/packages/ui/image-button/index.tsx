'use client'

import { Picture } from '@gravity-ui/icons'
import { Button, Flex, Icon, Text, useFileInput } from '@gravity-ui/uikit'
import { useCallback, useMemo, useState } from 'react'
import { CropperProps } from 'react-easy-crop'
import { FieldPath, UseFormRegister } from 'react-hook-form'
import { useToggle } from 'react-use'

import { useFile } from '~packages/hooks'
import { IMAGE_FILE_TYPES } from '~packages/system'
import { CropImage } from '~packages/ui'
import { imageSrcToFile } from '~packages/utils'

interface ImageButtonProps<T = any> {
	buttonText?: string
	name: string
	required?: boolean
	errorMessage?: string
	onChange: ({ file, src }: { file: File; src: string }) => void
	loading?: boolean
	aspect?: number
	accept?: string[]
	cropShape?: CropperProps['cropShape']
	register: UseFormRegister<T>
}

export function ImageButton<T = any>({
	name,
	buttonText,
	errorMessage,
	onChange,
	required,
	loading,
	aspect,
	accept = IMAGE_FILE_TYPES,
	cropShape,
	register,
}: ImageButtonProps<T>) {
	const [text, setText] = useState<string>(buttonText || 'Загрузить файл')
	const [val, toggle] = useToggle(false)
	const { result, setFiles } = useFile()
	const onUpdate = useCallback(
		(files: File[]) => {
			setFiles(files)
			toggle()
		},
		[toggle, setFiles],
	)
	const { controlProps, triggerProps } = useFileInput({ onUpdate })

	const cropHandler = async (img: string) => {
		const file = await imageSrcToFile(img)
		setText(file.name)
		onChange({
			file,
			src: img,
		})
	}

	const buttonStyle = useMemo(
		() => ({
			border: `1px solid ${!errorMessage ? 'transparent' : 'var(--g-color-text-danger)'}`,
			color: !errorMessage
				? 'var(--g-color-text-primary)'
				: 'var(--g-color-text-danger)',
		}),
		[errorMessage],
	)

	return (
		<>
			<CropImage
				cropShape={cropShape || 'rect'}
				aspect={aspect}
				image={result}
				setCropedImage={cropHandler}
				open={val}
				onClose={toggle}
			/>
			<Flex direction={'column'}>
				<Button
					width={'auto'}
					style={buttonStyle}
					size={'l'}
					view={errorMessage ? 'outlined-danger' : 'normal'}
					{...triggerProps}
				>
					<Icon data={Picture} size={18} />
					{text}
				</Button>
				{errorMessage && <Text color={'danger'}>{errorMessage}</Text>}
				<input
					ref={register(name as FieldPath<T>).ref}
					name={name}
					id={name}
					required={required || false}
					disabled={loading || false}
					hidden={true}
					type='file'
					accept={accept?.join(',')}
					multiple={false}
					{...controlProps}
				/>
			</Flex>
		</>
	)
}
